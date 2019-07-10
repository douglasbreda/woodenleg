using System.Collections.Generic;
using MongoDB.Driver;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Infra.Data.Data;
using WoodenLeg.Infra.Data.Test.DataTest;
using Xunit;

namespace WoodenLeg.Infra.Data.Test.Data
{
    public class MongoAccessTest
    {
        #region [Properties]

        private readonly string _dataBaseName = "WoodenLeg";
        private string _collectionName = "Player";

        #endregion

        #region [Tests]

        [Fact]
        public void GetCollectionWithDbParameterTest()
        {
            var _mongoMock = new MongoAccess();
            IMongoDatabase mongoDatabase = _mongoMock.GetDataBase( _dataBaseName );
            IMongoCollection<Player> players = _mongoMock.GetCollection<Player>( mongoDatabase, _collectionName );

            Assert.Equal( _collectionName, players.CollectionNamespace.CollectionName );
        }

        [Fact]
        public void GetCollectionWithLocalDbTest()
        {
            var _mongoMock = new MongoAccess();
            IMongoCollection<Player> players = _mongoMock.GetCollection<Player>( _collectionName );

            Assert.Equal( _collectionName, players.CollectionNamespace.CollectionName );
        }

        [Fact]
        public void GetDataBaseTest()
        {
            var _mongoMock = new MongoAccess();
            IMongoDatabase _mongoDb = _mongoMock.GetDataBase( _dataBaseName );

            if ( _mongoDb != null )
                Assert.Equal( _dataBaseName, _mongoDb.DatabaseNamespace.DatabaseName );
            else
                Assert.True( false, "Wasn't possible to retrieve mongo database" );
        }

        [Fact]
        public void InsertTest( )
        {
            var _mongoMock = new MongoAccess();
            List<Player> players = new List<Player>( new CollectionGenerator().GeneratePlayerCollection( 10 ) );
            _mongoMock.Insert( _mongoMock.GetCollection<Player>( _collectionName ), players );

            IMongoCollection<Player> playersInserted = _mongoMock.GetCollection<Player>( _collectionName );

            Assert.Equal( 10, playersInserted.CountDocuments( new FilterDefinitionBuilder<Player>().Empty ) );

            Player _player;
            for ( int i = 0; i < playersInserted.CountDocuments( new FilterDefinitionBuilder<Player>().Empty ); i++ )
            {
                _player = playersInserted.Find( x => x.Name.Equals( $"Player{i}" ) ).Single();
                if ( _player != null )
                    Assert.Equal( $"Player{i}", _player.Name );
                else
                    Assert.True( false, "One of the players wasn't inserted" );
            }   
        }

        [Fact]
        public void StartConnection()
        {
            var _mongoMock = new MongoAccess();
            Assert.True( _mongoMock.StartConnection() );
        }

        #endregion
    }
}
