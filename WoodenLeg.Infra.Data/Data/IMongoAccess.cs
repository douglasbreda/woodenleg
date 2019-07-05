using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WoodenLeg.Infra.Data.Data
{
    /// <summary>
    /// Access the properties from MongoDB
    /// </summary>
    public interface IMongoAccess : IDataAccessBase
    {
        #region [Definitions]

        ///<summary>
        /// Returns a database as mongo object
        ///</summary>
        IMongoDatabase GetDataBase( string dataBaseName );

        ///<summary>
        /// Returns a collection from a specific database
        ///</summary>
        IMongoCollection<T> GetCollection<T>( IMongoDatabase db, string collectionName );

        ///<summary>
        /// Returns a collection from the local database
        ///</summary>
        IMongoCollection<T> GetCollection<T>( string collectionName );

        ///<summary>
        /// Insert new items in a collection
        ///</summary>
        Task Insert<T>( IMongoCollection<T> collection, IEnumerable<T> data );

        #endregion
    }
}
