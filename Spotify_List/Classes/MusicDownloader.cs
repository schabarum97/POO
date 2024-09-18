using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MusicDownloader : IMusicDownloader
{
    private readonly IYouTubeService _youtubeService;
    private readonly ISpotifyService _spotifyService;

    public MusicDownloader(IYouTubeService youtubeService, ISpotifyService spotifyService)
    {
        _youtubeService = youtubeService;
        _spotifyService = spotifyService;
    }

    public async Task BaixarMusicasDoSpotifyAsync(string urlSpotify, string diretorioSaida, bool isPlaylist)
    {
        if (isPlaylist)
        {
            var playlistMusicas = await _spotifyService.ObterNomesMusicasPlaylistAsync(urlSpotify);

            Console.WriteLine("Iniciando download da playlist...");

            foreach (var musica in playlistMusicas)
            {
                Console.WriteLine($"Buscando vídeo para a consulta: {musica}");
                var urlVideo = await _youtubeService.BuscarVideoNoYouTubeAsync(musica);

                if (!string.IsNullOrEmpty(urlVideo))
                {
                    Console.WriteLine($"Baixando {musica}...");
                    await _youtubeService.BaixarDoYouTubeAsync(urlVideo, diretorioSaida);
                    Console.WriteLine($"Download de {musica} concluído!");
                }
                else
                {
                    Console.WriteLine($"Nenhum vídeo encontrado para a consulta: {musica}");
                }
            }
        }
        else
        {
            var nomeMusica = await _spotifyService.ObterNomeMusicaAsync(urlSpotify);
            Console.WriteLine($"Buscando vídeo para a consulta: {nomeMusica}");

            var urlVideo = await _youtubeService.BuscarVideoNoYouTubeAsync(nomeMusica);
            if (!string.IsNullOrEmpty(urlVideo))
            {
                Console.WriteLine($"Baixando {nomeMusica}...");
                await _youtubeService.BaixarDoYouTubeAsync(urlVideo, diretorioSaida);
                Console.WriteLine($"Download de {nomeMusica} concluído!");
            }
            else
            {
                Console.WriteLine($"Nenhum vídeo encontrado para a consulta: {nomeMusica}");
            }
        }
    }

    public async Task BaixarMusicasDoYouTubeAsync(string urlYouTube, string diretorioSaida)
    {
        if (urlYouTube.Contains("playlist?list="))
        {
            var urlsPlaylist = await _youtubeService.ObterUrlsPlaylistAsync(urlYouTube);

            Console.WriteLine("Iniciando download da playlist...");

            foreach (var urlVideo in urlsPlaylist)
            {
                Console.WriteLine($"Baixando vídeo da playlist: {urlVideo}");

                try
                {
                    await _youtubeService.BaixarDoYouTubeAsync(urlVideo, diretorioSaida);
                    Console.WriteLine($"Download do vídeo {urlVideo} concluído!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao baixar o vídeo: {urlVideo}. Detalhes: {ex.Message}");
                }
            }
        }
        else
        {
            try
            {
                await _youtubeService.BaixarDoYouTubeAsync(urlYouTube, diretorioSaida);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao baixar o vídeo: {ex.Message}");
            }
        }
    }

    public async Task BuscarEBaixarDoYouTubeAsync(string termoBusca, string diretorioSaida)
    {
        try
        {
            var resultados = await _youtubeService.BuscarVideosNoYouTubeAsync(termoBusca);
            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum vídeo encontrado.");
                return;
            }

            Console.WriteLine("Selecione o número do vídeo que deseja baixar:");
            for (int i = 0; i < resultados.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {resultados[i].Title}");
            }

            if (int.TryParse(Console.ReadLine(), out int selecao) && selecao > 0 && selecao <= resultados.Count)
            {
                await _youtubeService.BaixarDoYouTubeAsync(resultados[selecao - 1].Url, diretorioSaida);
            }
            else
            {
                Console.WriteLine("Seleção inválida.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar ou baixar o vídeo: {ex.Message}");
        }
    }
}
