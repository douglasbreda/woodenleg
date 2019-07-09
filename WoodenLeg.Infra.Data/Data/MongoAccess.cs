using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WoodenLeg.CrossCutting.Helpers;
using System.Linq;

namespace WoodenLeg.Infra.Data.Data
{
    public class MongoAccess : IMongoAccess
    {

        #region [Properties]

        private string _connectionString = "mongodb://localhost";

        private IMongoDatabase _dataBase = null;

        private MongoClient _mongoClient = null;

        private string _baseName = "WoodenLeg";

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

        /// <summary>
        /// To check if the server is connected
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Returns a collection by name and database instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public IMongoCollection<T> GetCollection<T>( IMongoDatabase db, string collectionName )
        {
            return db.GetCollection<T>( collectionName );
        }

        /// <summary>
        /// Returns a collection by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public IMongoCollection<T> GetCollection<T>( string collectionName )
        {
            return _dataBase.GetCollection<T>( collectionName );
        }

        /// <summary>
        /// Returns the instance of the database by name
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public IMongoDatabase GetDataBase( string dataBaseName )
        {
            string _baseName = _mongoClient.ListDatabaseNames()
                                           .ToList()
                                           .Where( x => x.Equals( dataBaseName ) )
                                           .FirstOrDefault();

            if ( _baseName.HasValue() )
                _dataBase = _mongoClient.GetDatabase( dataBaseName );
            else
                return null;
            
            return _dataBase;
        }

        /// <summary>
        /// Insert in a collection an enumerable of T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Insert<T>( IMongoCollection<T> collection, IEnumerable<T> data )
        {
            return collection.InsertManyAsync( data );
        }

        /// <summary>
        /// Start the connection with the database server
        /// </summary>
        /// <returns></returns>
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
