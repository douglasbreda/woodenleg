using System;
using System.Collections.Generic;
using WoodenLeg.CrossCutting.Helpers;
using WoodenLeg.Domain.Entities;

namespace WoodenLeg.Infra.Data.Test.DataTest
{
    /// <summary>
    /// Creates collections for test
    /// </summary>
    public class CollectionGenerator
    {
        #region [Properties]

        public string CollectionName { get; private set; }

        #endregion

        #region [Methods]

        /// <summary>
        /// Generates player collection for unit tests
        /// </summary>
        /// <param name="numberOfInstances"></param>
        /// <returns></returns>
        public IEnumerable<Player> GeneratePlayerCollection( int numberOfInstances )
        {
            CollectionName = "Player";
            List<Player> _playerList = new List<Player>();

            for ( int i = 0; i < numberOfInstances; i++ )
            {
                _playerList.Add( new Player { Id = Guid.NewGuid().ToString(), Name = $"Player{i}", Team = $"Team{i}" } );
            }

            return _playerList;
        }

        /// <summary>
        /// Returns a single entity used to test
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public TestEntity CreateSingleTestEntity( string name = "" )
        {
            return new TestEntity
            {
                Id = Guid.NewGuid().ToString(),
                Description = name.HasValue() ? name : $"Test entity {new Random().Next( 1000 )}"
            };
        }

        /// <summary>
        /// Returns a list of instances from TestEntity
        /// </summary>
        /// <param name="numberOfInstances"></param>
        /// <returns></returns>
        public List<TestEntity> CreateListTestEntity( int numberOfInstances )
        {
            List<TestEntity> _testEntityList = new List<TestEntity>();

            for ( int i = 0; i < numberOfInstances; i++ )
            {
                _testEntityList.Add( new TestEntity { Id = Guid.NewGuid().ToString(), Description = $"Default description {i}" } );
            }

            return _testEntityList;
        }

        #endregion
    }
}
