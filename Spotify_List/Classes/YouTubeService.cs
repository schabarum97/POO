using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Search;
using YoutubeExplode.Videos.Streams;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Spotify_List.Classes;

public class YouTubeService : IYouTubeService
{
    private readonly YoutubeClient _youtubeClient;
    private static int _totalTracksProcessed = 0;

    public YouTubeService()
    {
        _youtubeClient = new YoutubeClient();
    }

    public async Task BaixarDoYouTubeAsync(string urlVideo, string diretorioSaida)
    {
        if (!Directory.Exists(diretorioSaida))
        {
            Directory.CreateDirectory(diretorioSaida);
        }

        var videoId = ExtrairVideoId(urlVideo);
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
            var caminhoTemp = Path.Combine(diretorioSaida, "temp_video.mp4");

            await _youtubeClient.Videos.Streams.DownloadAsync(streamInfo, caminhoTemp);

            Console.WriteLine("\nDownload concluído!");

            var nomeArquivoSanitizado = SanitizarNomeArquivo($"{video.Title}.mp3");
            var caminhoMp3 = Path.Combine(diretorioSaida, nomeArquivoSanitizado);

            await ConverterParaMp3Async(caminhoTemp, caminhoMp3);

            File.Delete(caminhoTemp);

            _totalTracksProcessed++;
            Console.WriteLine($"Música baixada: {caminhoMp3}");
            Console.WriteLine($"Total de músicas processadas: {_totalTracksProcessed}");
        }
        else
        {
            Console.WriteLine("Não foi possível encontrar um fluxo de vídeo apropriado.");
        }
    }

    public async Task<string> BuscarVideoNoYouTubeAsync(string consulta)
    {
        Console.WriteLine($"Buscando vídeo para a consulta: {consulta}");
        var resultadosBusca = await _youtubeClient.Search.GetVideosAsync(consulta).CollectAsync(1);
        var primeiroResultado = resultadosBusca.FirstOrDefault();
        if (primeiroResultado != null)
        {
            Console.WriteLine($"Primeiro resultado: {primeiroResultado.Title} ({primeiroResultado.Url})");
            return primeiroResultado.Url;
        }
        else
        {
            Console.WriteLine("Nenhum vídeo encontrado.");
        }
        return null;
    }

    public async Task<List<ResultadoBuscaVideo>> BuscarVideosNoYouTubeAsync(string consulta, int limite = 10)
    {
        var resultadosBusca = await _youtubeClient.Search.GetVideosAsync(consulta).CollectAsync(limite);
        return resultadosBusca.Select(v => new ResultadoBuscaVideo { Title = v.Title, Url = v.Url }).ToList();
    }

    public async Task<List<string>> ObterUrlsPlaylistAsync(string urlPlaylist)
    {
        var playlist = await _youtubeClient.Playlists.GetVideosAsync(urlPlaylist);
        return playlist.Select(video => video.Url).ToList();
    }

    private string ExtrairVideoId(string urlVideo)
    {
        var uri = new Uri(urlVideo);
        var parametros = System.Web.HttpUtility.ParseQueryString(uri.Query);
        return parametros["v"];
    }

    private async Task ConverterParaMp3Async(string arquivoEntrada, string arquivoSaida)
    {
        var processStartInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg",
            Arguments = $"-i \"{arquivoEntrada}\" \"{arquivoSaida}\"",
            RedirectStandardError = true,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using (var processo = new Process { StartInfo = processStartInfo })
            {
                processo.Start();

                var erro = await processo.StandardError.ReadToEndAsync();
                var saida = await processo.StandardOutput.ReadToEndAsync();

                await processo.WaitForExitAsync();

                if (!string.IsNullOrEmpty(erro))
                {
                    if (erro.ToLower().Contains("error") ||
                        erro.ToLower().Contains("failed") ||
                        erro.ToLower().Contains("invalid"))
                    {
                        Console.WriteLine($"Erro durante a conversão de {arquivoEntrada} para {arquivoSaida}, possivelmente o vídeo não possui áudio.");
                    }
                }

                if (!string.IsNullOrEmpty(saida))
                {
                    Console.WriteLine("Saída padrão do FFmpeg:");
                    Console.WriteLine(saida);
                }

                if (processo.ExitCode != 0)
                {
                    Console.WriteLine($"O processo FFmpeg falhou com código de saída: {processo.ExitCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao converter o arquivo {arquivoEntrada}: {ex.Message}");
        }
    }

    private string SanitizarNomeArquivo(string nomeArquivo)
    {
        return Regex.Replace(nomeArquivo, "[^a-zA-Z0-9_\\-\\.]", "_");
    }
}
