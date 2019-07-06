using MongoDB.Driver;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Infra.Data.Data;
using Xunit;

namespace WoodenLeg.Infra.Data.Test.Data
{
    public class MongoAccessTest
    {
        #region [Properties]

        private readonly string _dataBaseName = "WoodenLeg";
        
        #endregion

        #region [Tests]

        [Fact]
        public void GetCollectionWithDbParameterTest()
        {
            Assert.True( false );
        }

        [Fact]
        public void GetCollectionWithLocalDbTest()
        {
            Assert.True( false );
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
            //_mongoMock.Insert(_mongoMock.GetCollection<>)
            _mongoMock.Insert( _mongoMock.GetCollection<Player>( _collectionName ), mates );
            Assert.True( false );
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
