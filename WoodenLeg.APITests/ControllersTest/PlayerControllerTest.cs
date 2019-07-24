using System;
using System.Collections.Generic;
using System.Linq;
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
        [Fact]
        public void GetAll()
        {
            PlayerGenerator _generator = new PlayerGenerator();
            List<Player> players = _generator.InsertPlayersForTest( 10 );

            var playerMock = GetPlayerAppServiceMock();
            playerMock.Setup( controller => controller.Get() ).Returns( players );

            var _playerController = new PlayerController( playerMock.Object );

            List<Player> newPlayers = _playerController.Get().ToList();

            Assert.Equal( players.Count, newPlayers.Count );

            Assert.Equal( players[3].Name, newPlayers[3].Name );
            Assert.Equal( players[3].Team, newPlayers[3].Team );
        }

        [Fact]
        public void GetPlayerById()
        {
            Player createdPlayer = new PlayerGenerator().GetSinglePlayer();
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
        public async void InsertOne()
        {
            //string id = Guid.NewGuid().ToString();
            //string name = "Insert test";
            //string team = "Team test";

            //Player newPlayer = new Player
            //{
            //    Id = id,
            //    Name = name,
            //    Team = team
            //};

            //var _playerController = NewController();
            //await _playerController.Post( newPlayer );

            //Player inserted = _playerController.GetById( id );

            //Assert.Equal( inserted.Id, id );
            //Assert.Equal( inserted.Name, name );
            //Assert.Equal( inserted.Team, team );
        }

        [Fact]
        public async void InsertOneNull()
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
            string id = Guid.NewGuid().ToString();
            string name = "Insert test";
            string team = "Team test";

            Player newPlayer = new Player
            {
                Id = id,
                Name = name,
                Team = team
            };

            var _playerController = new PlayerController( null /*new MongoAccess()*/ );
            await _playerController.Post( newPlayer );

            newPlayer.Name = "Name updated";
            newPlayer.Team = "Team updated";

            await _playerController.Update( newPlayer );

            Player playerUpdated = _playerController.GetById( newPlayer.Id );

            Assert.Equal( newPlayer.Name, playerUpdated.Name );
            Assert.Equal( newPlayer.Team, playerUpdated.Team );
        }

        [Fact]
        public async void Delete()
        {
            string id = Guid.NewGuid().ToString();
            string name = "Delete test";
            string team = "Team delete test";

            Player newPlayer = new Player
            {
                Id = id,
                Name = name,
                Team = team
            };

            var _playerController = new PlayerController( null/*new MongoAccess()*/ );
            await _playerController.Post( newPlayer );

            await _playerController.Delete( newPlayer );

            Player playerDeleted = _playerController.GetById( newPlayer.Id );

            Assert.Null( playerDeleted );
        }

        /// <summary>
        /// To centralize the creation of player mock because this will be used in many methods
        /// </summary>
        /// <returns></returns>
        private Mock<IPlayerAppService> GetPlayerAppServiceMock()
        {
            return new Mock<IPlayerAppService>();
        }
    }
}
