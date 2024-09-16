using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class SpotifyService
{
    private SpotifyClient _spotifyClient;

    // Inicializa o cliente do Spotify
    public async Task InitializeSpotifyClient(string clientId, string clientSecret)
    {
        var config = SpotifyClientConfig.CreateDefault();
        var request = new ClientCredentialsRequest(clientId, clientSecret);
        var response = await new OAuthClient(config).RequestToken(request);
        _spotifyClient = new SpotifyClient(config.WithToken(response.AccessToken));
    }

    // Extrai o ID da track da URL do Spotify
    public string ExtractSpotifyId(string spotifyUrl)
    {
        // Expressão regular para capturar IDs de músicas ou playlists, ignorando parâmetros como ?si=
        var match = Regex.Match(spotifyUrl, @"(?:https:\/\/open\.spotify\.com\/(?:intl-pt\/)?(?:track|playlist)\/|spotify:(track|playlist):)([a-zA-Z0-9]+)");
        if (match.Success)
        {
            return match.Groups[2].Value; // Captura o ID da música ou playlist
        }
        throw new ArgumentException("URL do Spotify inválida.");
    }
    // Obtém o nome da música pelo ID
    public async Task<string> GetTrackNameAsync(string trackUrlOrId)
    {
        // Extrai o ID se for uma URL
        string trackId = ExtractSpotifyId(trackUrlOrId);
        var track = await _spotifyClient.Tracks.Get(trackId);
        return $"{track.Name} - {track.Artists[0].Name}";
    }

    // Obtém os nomes das músicas de uma playlist
    public async Task<List<string>> GetPlaylistTrackNamesAsync(string playlistUrlOrId)
    {
        var playlistId = ExtractSpotifyId(playlistUrlOrId);
        var playlist = await _spotifyClient.Playlists.Get(playlistId);
        var trackNames = new List<string>();

        foreach (var item in playlist.Tracks.Items)
        {
            var track = item.Track as FullTrack;
            if (track != null)
            {
                trackNames.Add($"{track.Name} {track.Artists[0].Name}");
            }
        }

        return trackNames;
    }
}
