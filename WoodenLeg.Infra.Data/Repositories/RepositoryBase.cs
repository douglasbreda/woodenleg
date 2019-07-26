using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WoodenLeg.Domain.Interfaces.Entities;
using WoodenLeg.Domain.Interfaces.Repositories;
using WoodenLeg.Infra.Data.Data;

namespace WoodenLeg.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        #region [Attributes and Properties]

        //private readonly IMongoAccess _mongoAccess = null;
        public IMongoAccess MongoAccess { private get; set; }
        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public RepositoryBase()
        {
            //_mongoAccess = new MongoAccess();
        }

        #endregion

        #region [Interface implementation]

        public async Task<string> Create( TEntity entity )
        {
            string _errorMessage = string.Empty;
            if ( entity != null )
            {
                //TODO: Add validations
                try
                {
                    await MongoAccess.InsertOne( GetCollection(), entity );
                }
                catch ( MongoException ex )
                {
                    _errorMessage = ex.ToString();
                }
            }
            else
                _errorMessage = "The entity is null";

            return _errorMessage;
        }

        public async Task<bool> Delete( TEntity entity )
        {
            DeleteResult deleteResult = null;

            if ( entity != null )
                deleteResult = await MongoAccess.Delete( GetCollection(), entity.Id );

            return deleteResult.IsAcknowledged;
        }

        public void Dispose()
        {

        }

        public async Task<bool> Update( TEntity entity )
        {
            ReplaceOneResult updateResult = null;
            if ( entity != null )
            {
                var filterDefinition = Builders<TEntity>.Filter.Eq( "_id", entity.Id );
                updateResult = await MongoAccess.Update( GetCollection(), entity, filterDefinition );
            }

            return updateResult == null ? false : updateResult.IsAcknowledged;
        }

        public IEnumerable<TEntity> Get()
        {
            return GetCollection().Find( Builders<TEntity>.Filter.Empty ).ToList();
        }

        public TEntity GetById( string id )
        {
            var query = Builders<TEntity>.Filter.Eq( "_id", id );

            return GetCollection().Find( query ).FirstOrDefault();
        }

        /// <summary>
        /// Returns the collection of TEntity
        /// </summary>
        /// <returns></returns>
        private IMongoCollection<TEntity> GetCollection()
        {
            return MongoAccess.GetCollection<TEntity>( typeof( TEntity ).Name );
        }

        #endregion
    }
}
