using Spotify_List.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IYouTubeService
{
    Task BaixarDoYouTubeAsync(string urlVideo, string diretorioSaida);
    Task<string> BuscarVideoNoYouTubeAsync(string consulta);
    Task<List<ResultadoBuscaVideo>> BuscarVideosNoYouTubeAsync(string consulta, int limite = 10);
    Task<List<string>> ObterUrlsPlaylistAsync(string urlPlaylist);
}
