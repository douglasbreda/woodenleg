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
    public class PlayerControllerTest
    {
        #region [Attributes]

        private readonly PlayerGenerator _playerGenerator;

        #endregion

        #region [Constructor]

        public PlayerControllerTest()
        {
            _playerGenerator = new PlayerGenerator();
        }

        #endregion

        #region [Tests]

        [Fact]
        public void Get_All()
        {
            List<Player> players = _playerGenerator.InsertPlayersForTest( 10 );

            var playerMock = GetPlayerAppServiceMock();
            playerMock.Setup( controller => controller.Get() ).Returns( players );

            var _playerController = new PlayerController( playerMock.Object );

            List<Player> newPlayers = _playerController.Get().ToList();

            Assert.Equal( players.Count, newPlayers.Count );

            Assert.Equal( players[3].Name, newPlayers[3].Name );
            Assert.Equal( players[3].Team, newPlayers[3].Team );
        }

        [Fact]
        public void Get_Player_By_Id()
        {
            Player createdPlayer = _playerGenerator.GetSinglePlayer();
            string playerId = createdPlayer.Id;

            var playerMock = GetPlayerAppServiceMock();
            playerMock.Setup( x => x.GetById( playerId ) ).Returns( createdPlayer );

            var _playerController = new PlayerController( playerMock.Object );

            Player newPlayer = _playerController.GetById( playerId );

            Assert.Equal( createdPlayer.Id, newPlayer.Id );
            Assert.Equal( createdPlayer.Name, newPlayer.Name );
            Assert.Equal( createdPlayer.Team, newPlayer.Team );
        }

        [Fact]
        public async void Insert_One()
        {
            string name = "Insert test";
            string team = "Team test";

            Player newPlayer = _playerGenerator.GetSinglePlayer( name, team );
            var mockPlayer = GetPlayerAppServiceMock();

            mockPlayer.Setup( x => x.Create( newPlayer ) ).ReturnsAsync( string.Empty );
            var _playerController = new PlayerController( mockPlayer.Object );
            string result = await _playerController.Post( newPlayer );

            Assert.Equal( string.Empty, result );
        }
        

        [Fact]
        public async void Insert_One_Null()
        {
            Player newPlayer = null;
            var playerMock = GetPlayerAppServiceMock();
            string nullMessage = "The player is null";

            playerMock.Setup( x => x.Create( null ) ).ReturnsAsync( nullMessage );

            var _playerController = new PlayerController( playerMock.Object );
            string result =  await _playerController.Post( newPlayer );

            Assert.Equal( nullMessage, result );
        }

        [Fact]
        public async void Update()
        {
            Player player = _playerGenerator.GetSinglePlayer();
            var mockPlayer = new Mock<IPlayerAppService>();

            mockPlayer.Setup( x => x.Update( It.IsAny<Player>() ) ).ReturnsAsync( true );

            var _playerController = new PlayerController( mockPlayer.Object );
            ActionResult result = await _playerController.Update( player );

            Assert.Equal( typeof(OkResult), result.GetType() );
        }

        [Fact]
        public async void Delete()
        {
            Player player = _playerGenerator.GetSinglePlayer();
            var mockPlayer = new Mock<IPlayerAppService>();

            mockPlayer.Setup( x => x.Delete( player ) ).ReturnsAsync( true );

            var _playerController = new PlayerController( mockPlayer.Object );

            ActionResult action = await _playerController.Delete( player );

            Assert.Equal( typeof( OkResult ), action.GetType() );
        }

        #endregion

        #region [Auxiliar Methods]

        /// <summary>
        /// To centralize the creation of player mock because this will be used in many methods
        /// </summary>
        /// <returns></returns>
        private Mock<IPlayerAppService> GetPlayerAppServiceMock()
        {
            return new Mock<IPlayerAppService>();
        }

        #endregion
    }
}
