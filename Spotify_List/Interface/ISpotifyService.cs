using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISpotifyService
{
    Task InicializarAsync(string clientId, string clientSecret);
    Task<string> ObterNomeMusicaAsync(string urlOuIdMusica);
    Task<List<string>> ObterNomesMusicasPlaylistAsync(string urlOuIdPlaylist);
}
