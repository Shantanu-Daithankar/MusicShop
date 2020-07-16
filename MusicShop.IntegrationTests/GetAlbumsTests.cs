using System;
using System.Collections.Generic;
using NUnit.Framework;
using MusicShop.Entities;
using MusicShop.Services;
using MusicShop.Interfaces;

namespace MusicShop.IntegrationTests
{
    [TestFixture]
    class GetAlbumsTests
    {        
        IAlbumService albumService;        

        [SetUp]
        public void SetUp()
        {
            albumService = BootStrap.Container.Resolve<IAlbumService>();
        }


        [Test]
        public void Album_Details_Are_Returned_When_Queried_By_Album_Name()
        {
            var albumsByAlbumName = albumService.GetAlbumsByAlbumName("Load");

            Assert.AreEqual(1, albumsByAlbumName.Count, "Album counts dont match");

            Assert.AreEqual("Load", albumsByAlbumName[0].Title, "Album titles dont match");
        }

        [Test]
        public void Album_Details_Are_Returned_When_Queried_By_Artist_Name()
        {            
            var albumsByArtistName = albumService.GetAlbumsByArtistName("Metallica");

            Assert.AreEqual(10, albumsByArtistName.Count, "Album counts dont match");            
        }

        [Test]
        public void Album_Details_Are_Returned_When_Queried_By_Album_Name_And_Artist_Name()
        {            
            var albumsByArtistAndName = albumService.GetAlbumsByArtistAndAlbumName("Metallica", "Load");

            Assert.AreEqual(1, albumsByArtistAndName.Count, "Album counts dont match");

            Assert.AreEqual("Load", albumsByArtistAndName[0].Title, "Album titles dont match");
        }
    }
}
