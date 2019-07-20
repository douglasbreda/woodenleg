﻿using System;
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

        private readonly IMongoAccess _mongoAccess = null;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public RepositoryBase()
        {
            _mongoAccess = new MongoAccess();
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
                    await _mongoAccess.InsertOne( GetCollection(), entity );
                }
                catch ( MongoException ex )
                {
                    _errorMessage = ex.ToString();
                }
            }

            return _errorMessage;
        }

        public async Task<bool> Delete( TEntity entity )
        {
            DeleteResult deleteResult = null;

            if ( entity != null )
                deleteResult = await _mongoAccess.Delete( GetCollection(), entity.Id );

            return deleteResult.IsAcknowledged;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update( TEntity entity )
        {
            ReplaceOneResult updateResult = null;
            if ( entity != null )
            {
                var filterDefinition = Builders<TEntity>.Filter.Eq( "_id", entity.Id );
                updateResult = await _mongoAccess.Update( GetCollection(), entity, filterDefinition );
            }

            return updateResult.IsAcknowledged;
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
            return _mongoAccess.GetCollection<TEntity>( typeof( TEntity ).Name );
        }

        #endregion
    }
}
