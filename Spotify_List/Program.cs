using System;
using System.Threading.Tasks;
using System.IO;

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
        await spotifyService.InicializarAsync(clientId, clientSecret);

        // Diretório padrão
        string defaultOutputDirectory = Path.Combine(Environment.CurrentDirectory, "Downloads");

        Console.WriteLine("Digite '-help' para ver os comandos disponíveis.");

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nDigite um comando:");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Comando vazio. Digite '-help' para ver os comandos disponíveis.");
                continue;
            }

            string[] inputArgs = input.Split(' ');

            string comando = inputArgs[0].ToLower();
            string url = inputArgs.Length > 1 ? inputArgs[1] : null;
            string diretorioSaida = inputArgs.Length > 2 ? inputArgs[2] : defaultOutputDirectory;

            switch (comando)
            {
                case "-spotify":
                    if (url != null && url.Contains("playlist"))
                    {
                        await downloader.BaixarMusicasDoSpotifyAsync(url, diretorioSaida, true);
                    }
                    else if (url != null)
                    {
                        await downloader.BaixarMusicasDoSpotifyAsync(url, diretorioSaida, false);
                    }
                    else
                    {
                        Console.WriteLine("URL do Spotify não fornecida.");
                    }
                    break;

                case "-youtube":
                    if (url != null)
                    {
                        await downloader.BaixarMusicasDoYouTubeAsync(url, diretorioSaida);
                    }
                    else
                    {
                        Console.WriteLine("URL do YouTube não fornecida.");
                    }
                    break;

                case "-search":
                    if (url != null)
                    {
                        await downloader.BuscarEBaixarDoYouTubeAsync(url, diretorioSaida);
                    }
                    else
                    {
                        Console.WriteLine("Termo de busca não fornecido.");
                    }
                    break;

                case "-help":
                    MostrarAjuda();
                    break;

                case "-exit":
                    running = false;
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Comando não reconhecido.");
                    MostrarAjuda();
                    break;
            }

            // Exibe o diretório de saída padrão
            Console.WriteLine($"Diretório de saída: {diretorioSaida}");
        }
    }

    static void MostrarAjuda()
    {
        Console.WriteLine("Uso:");
        Console.WriteLine("-spotify [URL] [diretorioSaida]   : Baixar música ou playlist do Spotify");
        Console.WriteLine("-youtube [URL] [diretorioSaida]   : Baixar vídeo ou playlist do YouTube");
        Console.WriteLine("-search [termo] [diretorioSaida]  : Buscar vídeo no YouTube por termo e baixar");
        Console.WriteLine("-help                             : Mostrar ajuda");
        Console.WriteLine("-exit                             : Sair do programa");
    }
}
