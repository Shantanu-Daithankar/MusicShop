using MusicShop.Entities;
using MusicShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services
{
    public class AlbumService : IAlbumService
    {
        IRepositoryService _repositoryService;

        public AlbumService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public List<Album> GetAlbumsByArtistName(string artistName)
        {
            string query = @"select al.AlbumId, al.Title, al.ArtistId
                            from albums al
                            join artists ar
                            on al.artistId = ar.ArtistId
                            where ar.Name = @artistName";

            return _repositoryService.Get<Album>(query, new { artistName });
        }

        public List<Album> GetAlbumsByAlbumName(string albumName)
        {
            string query = @"select al.AlbumId, al.Title, al.ArtistId
                             from albums al
                             where al.Title = @albumName";

            return _repositoryService.Get<Album>(query, new { albumName });
        }

        public List<Album> GetAlbumsByArtistAndAlbumName(string artistName, string albumName)
        {
            string query = @"select al.AlbumId, al.Title, al.ArtistId
                            from albums al
                            join artists ar
                            on al.artistId = ar.ArtistId
                            where ar.Name = @artistName
                            intersect
                            select al.AlbumId, al.Title, al.ArtistId
                            from albums al
                            where al.Title = @albumName";

            return _repositoryService.Get<Album>(query, new { artistName, albumName });
        }

    }
}
