using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Infra.Data.Data;

namespace WoodenLeg.APITests.Helpers
{
    public class PlayerGenerator
    {
        #region [Methods]

        /// <summary>
        /// Insert new players to check 
        /// </summary>
        /// <param name="instances"></param>
        /// <returns></returns>
        public async Task InsertPlayersForTest( int instances )
        {
            MongoAccess _mongo = new MongoAccess();
            _mongo.StartConnection();

            List<Player> _playerList = new List<Player>();

            for ( int i = 0; i < instances; i++ )
            {
                _playerList.Add( new Player
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"Player{i}",
                    Team = $"Team{i}"
                } );
            }

            IMongoCollection<Player> _mongoCollection = _mongo.GetCollection<Player>( nameof( Player ) );
            RemoveAllDocuments( _mongoCollection );

            await _mongo.InsertMany( _mongoCollection, _playerList );
        }

        /// <summary>
        /// Cleans the database to allow a new test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        private void RemoveAllDocuments<T>( IMongoCollection<T> collection )
        {
            collection.DeleteMany( Builders<T>.Filter.Empty );
        }

        #endregion
    }
}
