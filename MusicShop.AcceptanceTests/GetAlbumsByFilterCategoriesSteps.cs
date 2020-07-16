using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicShop;
using MusicShop.Entities;
using MusicShop.Interfaces;
using MusicShop.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Assert = NUnit.Framework.Assert;

namespace Explore.AcceptanceTests
{    

    [Binding]
    public class GetAlbumsByFilterCategoriesSteps
    {        
        IAlbumService albumService;
        
        List<Album> actualAlbums = new List<Album>();        

        List<string> expectedArtists;


        [Given(@"The MusicShop app is online")]
        public void TheMusicShopAppIsOnline()
        {            
            albumService = BootStrap.Container.Resolve<IAlbumService>();
        }

        [Given(@"I have entered the name of the artists :")]
        public void GivenIHaveEnteredTheNameOfTheArtists(Table table)
        {
            expectedArtists = table.CreateSet<string>((tr) => tr["ArtistName"]).ToList();
        }
        
        [When(@"I request for albums data")]
        public void WhenIRequestForAlbumsData()
        {
            foreach(string artistName in expectedArtists)
            {
                var albumsByCurrentArtist = albumService.GetAlbumsByArtistName(artistName);

                actualAlbums.AddRange(albumsByCurrentArtist);
            }
        }
        
        [Then(@"the result should be the album's information as below :")]
        public void ThenTheResultShouldBeTheAlbumSInformationAsBelow(Table table)
        {            
            Assert.DoesNotThrow(()=>table.CompareToSet<Album>(actualAlbums), "mismatch found in the result set in artist's albums");            
        }
    }
}
