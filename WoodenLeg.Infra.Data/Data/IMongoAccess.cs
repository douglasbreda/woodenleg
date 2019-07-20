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
        Task InsertMany<T>( IMongoCollection<T> collection, IEnumerable<T> data );

        /// <summary>
        /// Insert one single document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        Task InsertOne<T>( IMongoCollection<T> collection, T document );

        /// <summary>
        /// Replace the information of a specific document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="document"></param>
        /// <returns></returns>
        Task<ReplaceOneResult> Update<T>( IMongoCollection<T> collection, T document, FilterDefinition<T> filter );

        /// <summary>
        /// Delete a document
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DeleteResult> Delete<T>( IMongoCollection<T> collection, string id );

        #endregion
    }
}
