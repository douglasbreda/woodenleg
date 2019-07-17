using System;
using System.Collections.Generic;
using System.Linq;
using WoodenLeg.API.Controllers;
using WoodenLeg.APITests.Helpers;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Infra.Data.Data;
using Xunit;

namespace WoodenLeg.APITests.ControllersTest
{
    public class PlayerControllerTest
    {
        [Fact]
        public async void GetAll()
        {
            PlayerGenerator _generator = new PlayerGenerator();
            await _generator.InsertPlayersForTest( 10 );

            var _playerController = new PlayerController( new MongoAccess() );

            List<Player> players = _playerController.Get().ToList();

            Assert.Equal( 10, players.Count );

            Assert.Equal( "Player3", players[3].Name );
            Assert.Equal( "Team3", players[3].Team );
        }

        [Fact]
        public void GetPlayerById()
        {
            var _playerController = new PlayerController( new MongoAccess() );

            List<Player> players = _playerController.Get().ToList();

            int index = new Random().Next( 0, 9 );

            Player playerSelected = players.ElementAt( index );

            Player newPlayer = _playerController.GetById( playerSelected.Id );

            Assert.Equal( playerSelected.Id, newPlayer.Id );
            Assert.Equal( playerSelected.Name, newPlayer.Name );
            Assert.Equal( playerSelected.Team, newPlayer.Team );

        }

        [Fact]
        public async void InsertOne()
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

            var _playerController = new PlayerController( new MongoAccess() );
             await _playerController.Post( newPlayer );

            Player inserted = _playerController.GetById( id );

            Assert.Equal( inserted.Id, id );
            Assert.Equal( inserted.Name, name );
            Assert.Equal( inserted.Team, team );
        }

        [Fact]
        public async void InsertOneNull()
        {
            Player newPlayer = null;

            var _playerController = new PlayerController( new MongoAccess() );
            string result = await _playerController.Post( newPlayer );

            Assert.Equal( "The player is null", result );
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

            var _playerController = new PlayerController( new MongoAccess() );
            await _playerController.Post( newPlayer );

            newPlayer.Name = "Name updated";
            newPlayer.Team = "Team updated";

            //_playerController.Update(newPlayer)
            Assert.True( false );
        }
    }
}
