using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class SpotifyService : ISpotifyService
{
    private SpotifyClient _spotifyClient;

    public async Task InicializarAsync(string clientId, string clientSecret)
    {
        var config = SpotifyClientConfig.CreateDefault();
        var request = new ClientCredentialsRequest(clientId, clientSecret);
        var response = await new OAuthClient(config).RequestToken(request);
        _spotifyClient = new SpotifyClient(config.WithToken(response.AccessToken));
    }

    public async Task<string> ObterNomeMusicaAsync(string urlOuIdMusica)
    {
        string idMusica = ExtrairIdSpotify(urlOuIdMusica, "track");
        var musica = await _spotifyClient.Tracks.Get(idMusica);
        return $"{musica.Name} - {musica.Artists[0].Name}";
    }

    public async Task<List<string>> ObterNomesMusicasPlaylistAsync(string urlOuIdPlaylist)
    {
        var idPlaylist = ExtrairIdSpotify(urlOuIdPlaylist, "playlist");
        var playlist = await _spotifyClient.Playlists.Get(idPlaylist);
        var nomesMusicas = new List<string>();

        foreach (var item in playlist.Tracks.Items)
        {
            if (item.Track is FullTrack track)
            {
                nomesMusicas.Add($"{track.Name} - {track.Artists[0].Name}");
            }
        }

        return nomesMusicas;
    }

    private string ExtrairIdSpotify(string urlSpotify, string tipo)
    {
        var padrao = $@"(?:https:\/\/open\.spotify\.com\/(?:intl-pt\/)?{tipo}\/|spotify:{tipo}:)([a-zA-Z0-9]+)";
        var match = Regex.Match(urlSpotify, padrao);
        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        throw new ArgumentException("URL do Spotify inválida.");
    }
}
