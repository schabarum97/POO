using YoutubeExplode;
using YoutubeExplode.Converter;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using YoutubeExplode.Common;
using YoutubeExplode.Search;
using YoutubeExplode.Videos.Streams;
using System.Text.RegularExpressions;
using System.Timers;

public class YouTubeService
{
    private readonly YoutubeClient _youtubeClient;
    private static int _totalTracksProcessed = 0; // Contador de músicas processadas

    public YouTubeService()
    {
        _youtubeClient = new YoutubeClient();
    }

    public async Task DownloadFromYouTubeAsync(string videoUrl, string outputDirectory)
    {
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        var videoId = ExtractVideoId(videoUrl);
        if (string.IsNullOrEmpty(videoId))
        {
            throw new ArgumentException("A URL do vídeo não é válida.");
        }

        var video = await _youtubeClient.Videos.GetAsync(videoId);
        var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoId);
        var streamInfo = streamManifest.Streams
            .OrderBy(s => s.Bitrate)
            .FirstOrDefault();

        if (streamInfo != null)
        {
            var tempFilePath = Path.Combine(outputDirectory, "temp_video.mp4");

            await _youtubeClient.Videos.Streams.DownloadAsync(streamInfo, tempFilePath);

            Console.WriteLine("\nDownload concluído!");

            // Sanitize the video title to create a valid filename
            var sanitizedFileName = SanitizeFileName($"{video.Title}.mp3");
            var mp3FilePath = Path.Combine(outputDirectory, sanitizedFileName);

            await ConvertToMp3Async(tempFilePath, mp3FilePath);

            File.Delete(tempFilePath); // Remove o arquivo temporário

            // Atualiza o contador de músicas processadas
            _totalTracksProcessed++;
            Console.WriteLine($"Música baixada: {mp3FilePath}");
            Console.WriteLine($"Total de músicas processadas: {_totalTracksProcessed}");
        }
        else
        {
            Console.WriteLine("Não foi possível encontrar um fluxo de vídeo apropriado.");
        }
    }

    private string ExtractVideoId(string videoUrl)
    {
        // Extrair ID do vídeo da URL
        var uri = new Uri(videoUrl);
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
        return queryParams["v"];
    }

    private async Task ConvertToMp3Async(string inputFile, string outputFile)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = $"-i \"{inputFile}\" \"{outputFile}\"",
            RedirectStandardError = true,  // Redireciona o erro padrão
            RedirectStandardOutput = true, // Redireciona a saída padrão (opcional)
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.Start();

                // Lê o erro padrão em tempo real
                var errorReader = process.StandardError;
                string errorOutput = await errorReader.ReadToEndAsync();

                // Opcional: Lê a saída padrão se necessário (não crucial para o FFmpeg)
                var outputReader = process.StandardOutput;
                string standardOutput = await outputReader.ReadToEndAsync();

                await process.WaitForExitAsync();
                /*
                if (!string.IsNullOrEmpty(errorOutput))
                {
                    Console.WriteLine($"Erro durante a conversão de {inputFile} para {outputFile}:");
                    Console.WriteLine(errorOutput);
                }*/
                if (!string.IsNullOrEmpty(errorOutput))
                {
                    // Verifica se a saída de erro contém uma mensagem crítica
                    if (errorOutput.ToLower().Contains("error") ||
                        errorOutput.ToLower().Contains("failed") ||
                        errorOutput.ToLower().Contains("invalid"))
                    {
                        Console.WriteLine($"Erro durante a conversão de {inputFile} para {outputFile}, possível causa é que o vídeo encontrado no youtube não possui audio");
                    }
                }

                // Exibe a saída padrão se for útil (opcional)
                if (!string.IsNullOrEmpty(standardOutput))
                {
                    Console.WriteLine("Saída padrão do FFmpeg:");
                    Console.WriteLine(standardOutput);
                }

                if (process.ExitCode != 0)
                {
                    Console.WriteLine($"O processo FFmpeg falhou com código de saída: {process.ExitCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao converter o arquivo {inputFile}: {ex.Message}");
        }
    }

    private string SanitizeFileName(string fileName)
    {
        // Remove caracteres especiais
        return Regex.Replace(fileName, "[^a-zA-Z0-9_\\-\\.]", "_");
    }


    public async Task<string> SearchYouTubeVideoAsync(string query)
    {
        Console.WriteLine($"Buscando vídeo para a consulta: {query}");
        var searchResults = await _youtubeClient.Search.GetVideosAsync(query).CollectAsync(1);
        var firstResult = searchResults.FirstOrDefault();
        if (firstResult != null)
        {
            Console.WriteLine($"Primeiro resultado: {firstResult.Title} ({firstResult.Url})");
            return firstResult.Url;
        }
        else
        {
            Console.WriteLine("Nenhum vídeo encontrado.");
        }
        return null;
    }

    public async Task<List<VideoSearchResult>> SearchYouTubeVideosAsync(string query, int limit = 10)
    {
        var searchResults = await _youtubeClient.Search.GetVideosAsync(query).CollectAsync(limit);
        return searchResults.ToList();
    }

    public async Task<List<string>> GetPlaylistVideoUrlsAsync(string playlistUrl)
    {
        var youtube = new YoutubeClient();
        var playlist = await youtube.Playlists.GetVideosAsync(playlistUrl);

        var videoUrls = new List<string>();

        foreach (var video in playlist)
        {
            videoUrls.Add(video.Url);
        }

        return videoUrls;
    }
}
