using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WoodenLeg.API.Controllers;
using WoodenLeg.APITests.Helpers;
using WoodenLeg.Application.Interfaces;
using WoodenLeg.Domain.Entities;
using Xunit;

namespace WoodenLeg.APITests.ControllersTest
{
    public class AdvertisementControllerTest
    {
        #region [Properties]

        private AdvertisementGenerator _advertisementGenerator;

        #endregion

        #region [Constructor]

        public AdvertisementControllerTest()
        {
            _advertisementGenerator = new AdvertisementGenerator();
        }

        #endregion

        #region [Tests]

        private Mock<IAdvertisementAppService> GetMockAd()
        {
            return new Mock<IAdvertisementAppService>();
        }

        [Fact]
        public void Get_All()
        {
            List<Advertisement> _listAds = _advertisementGenerator.GenerateAds( 10 );
            var mockAd = GetMockAd();

            mockAd.Setup( x => x.Get() ).Returns( _listAds );

            var adController = new AdvertisementController( mockAd.Object );

            List<Advertisement> _newAds = adController.Get().ToList();

            Assert.Equal( _listAds.Count, _newAds.Count );

            Assert.Equal( _listAds[3], _newAds[3] );
            Assert.Equal( _listAds[5], _newAds[5] );
        }

        [Fact]
        public void Get_By_Id()
        {
            Advertisement _ad = _advertisementGenerator.GenerateSingleAd( "Teste By Id" );

            var mockAd = GetMockAd();

            mockAd.Setup( x => x.GetById( _ad.Id ) ).Returns( _ad );

            var adController = new AdvertisementController( mockAd.Object );

            Advertisement newAd = adController.GetById( _ad.Id );

            Assert.Equal( _ad, newAd );
        }

        [Fact]
        public async void Create_Ad_Test()
        {
            Advertisement _ad = _advertisementGenerator.GenerateSingleAd( "Teste Create" );

            var mockAd = GetMockAd();

            mockAd.Setup( x => x.Create( _ad ) ).ReturnsAsync( "" );

            var adController = new AdvertisementController( mockAd.Object );

            string result = await adController.Post( _ad );

            Assert.Equal( string.Empty, result );
        }

        [Fact]
        public async void Update_Ad_Test()
        {
            Advertisement _ad = _advertisementGenerator.GenerateSingleAd( "Teste Update" );

            var mockAd = GetMockAd();

            mockAd.Setup( x => x.Update( _ad ) ).ReturnsAsync( true );

            var adController = new AdvertisementController( mockAd.Object );

            ActionResult result = await adController.Update( _ad );

            Assert.Equal( typeof( OkResult ), result.GetType() );
        }

        [Fact]
        public async void Insert_One_Null()
        {
            Advertisement newAdd = null;
            var adMock = GetMockAd();
            string nullMessage = "The ad is null";

            adMock.Setup( x => x.Create( null ) ).ReturnsAsync( nullMessage );

            var adController = new AdvertisementController( adMock.Object );
            string result = await adController.Post( newAdd );

            Assert.Equal( nullMessage, result );
        }

        #endregion
    }
}
