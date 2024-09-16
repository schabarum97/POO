using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var youtubeService = new YouTubeService();
        var spotifyService = new SpotifyService();
        var downloader = new MusicDownloader(youtubeService, spotifyService);

        // Dados de autenticação do Spotify
        string clientId = "3b95d37efbaa45889de43289283c3fc0";
        string clientSecret = "db97eec9b2bf468e8e24cfc0a0a7dfcd";
        await spotifyService.InitializeSpotifyClient(clientId, clientSecret);

        while (true)
        {
            Console.WriteLine("Digite a URL ou o termo de busca:");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Saindo...");
                break;
            }

            string outputDirectory = null;
            if (input.Contains("spotify.com"))
            {
                Console.WriteLine("Digite o diretório onde os arquivos serão baixados:");
                outputDirectory = Console.ReadLine();
                Console.WriteLine("É uma playlist do Spotify? (s/n)");
                bool isSpotifyPlaylist = Console.ReadLine()?.ToLower() == "s";
                await downloader.DownloadMusicFromSpotifyAsync(input, outputDirectory, isSpotifyPlaylist);
            }
            else if (input.Contains("youtube.com"))
            {
                Console.WriteLine("Digite o diretório onde os arquivos serão baixados:");
                outputDirectory = Console.ReadLine();
                await downloader.DownloadMusicFromYouTubeAsync(input, outputDirectory);
            }
            else
            {
                Console.WriteLine("Digite o diretório onde os arquivos serão baixados:");
                outputDirectory = Console.ReadLine();
                await downloader.SearchAndDownloadFromYouTubeAsync(input, outputDirectory);
            }

            Console.WriteLine("Download concluído com sucesso!");
        }
    }
}
