using MusicShop.Entities;
using MusicShop.Interfaces;
using MusicShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop
{
    class Program
    {
        static void Main(string[] args)
        {
            var albumService = BootStrap.Container.Resolve<IAlbumService>();            

            var albumsByArtistName = albumService.GetAlbumsByArtistName("Metallica");

            PrintAlbumDetails("Albums By Artist Name =>", albumsByArtistName);

            var albumsByAlbumName = albumService.GetAlbumsByAlbumName("Load");

            PrintAlbumDetails("Albums By Album Name =>", albumsByAlbumName);

            var albumsByArtistAndName = albumService.GetAlbumsByArtistAndAlbumName("Metallica", "Load");

            PrintAlbumDetails("Albums By Artist And Name =>", albumsByArtistAndName);

            Console.ReadLine();
        }

        public static void PrintAlbumDetails(string resultType, List<Album> albums)
        {
            Console.WriteLine(resultType + Environment.NewLine + Environment.NewLine);

            foreach (Album album in albums)
            {
                Console.WriteLine(album.AlbumId.ToString());
                Console.WriteLine(album.Title);
                Console.WriteLine(album.ArtistId.ToString());

            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
