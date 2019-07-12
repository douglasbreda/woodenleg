using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
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

            //var _dbMock = new Mock<IMongoAccess>();
            //_dbMock.Setup( x => x.StartConnection() ).Returns( true );
            //_dbMock.Setup( x => x.GetCollection<Player>( nameof( Player ) ) );
            var _playerController = new PlayerController( new MongoAccess() );

            List<Player> players = _playerController.GetPlayers().ToList();

            Assert.Equal( 10, players.Count );

            Assert.Equal( 3, players[3].Id );
            Assert.Equal( "Player3", players[3].Name );
            Assert.Equal( "Team3", players[3].Team );


            Assert.False( true );
        }
    }
}
