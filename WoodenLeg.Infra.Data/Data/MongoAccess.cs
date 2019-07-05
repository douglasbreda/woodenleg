using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WoodenLeg.Infra.Data.Data
{
    public class MongoAccess : IMongoAccess
    {

        #region [Properties]

        private string _connectionString = "mongodb://localhost";

        private IMongoDatabase _dataBase = null;

        private string _baseName = "WoodenLeg";

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
            throw new NotImplementedException();
        }

        public Task Insert<T>( IMongoCollection<T> collection, IEnumerable<T> data )
        {
            throw new NotImplementedException();
        }

        public bool StartConnection()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
