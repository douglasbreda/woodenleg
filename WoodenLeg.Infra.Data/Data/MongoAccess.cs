using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using WoodenLeg.CrossCutting.Helpers;

namespace WoodenLeg.Infra.Data.Data
{
    public class MongoAccess : IMongoAccess
    {

        #region [Properties]

        private string _connectionString = "mongodb://localhost";

        private IMongoDatabase _dataBase = null;

        private MongoClient _mongoClient = null;

        private string _baseName = "WoodenLegTest";

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public MongoAccess()
        {
            StartConnection();
            GetDataBase( _baseName );
        }
        
        #endregion

        #region [Interface definitions]

        public bool IsConnected { get; set; }

        public IMongoCollection<T> GetCollection<T>( IMongoDatabase db, string collectionName )
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<T> GetCollection<T>( string collectionName )
        {
            throw new NotImplementedException();
        }

        public IMongoDatabase GetDataBase( string dataBaseName )
        {
            _dataBase = _mongoClient.GetDatabase( dataBaseName );

            return _dataBase;
        }

        public Task Insert<T>( IMongoCollection<T> collection, IEnumerable<T> data )
        {
            return collection.InsertManyAsync( data );
        }

        public bool StartConnection()
        {
            try
            {
                _mongoClient = new MongoClient( _connectionString );

                var mongoSession = _mongoClient.StartSession();

                IsConnected = true;

                return true;
            }
            catch ( MongoException ex )
            {
                IsConnected = false;
                Logger.LogError( ex.ToString() );
                return false;
            }
        }

        #endregion
    }
}
