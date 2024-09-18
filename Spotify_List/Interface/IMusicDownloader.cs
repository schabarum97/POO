using System.Threading.Tasks;

public interface IMusicDownloader
{
    Task BaixarMusicasDoSpotifyAsync(string urlSpotify, string diretorioSaida, bool isPlaylist);
    Task BaixarMusicasDoYouTubeAsync(string urlYouTube, string diretorioSaida);
    Task BuscarEBaixarDoYouTubeAsync(string termoBusca, string diretorioSaida);
}
