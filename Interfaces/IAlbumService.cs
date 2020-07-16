using MusicShop.Entities;
using System.Collections.Generic;

namespace MusicShop.Interfaces
{
    public interface IAlbumService
    {
        List<Album> GetAlbumsByAlbumName(string albumName);
        List<Album> GetAlbumsByArtistAndAlbumName(string artistName, string albumName);
        List<Album> GetAlbumsByArtistName(string artistName);
    }
}