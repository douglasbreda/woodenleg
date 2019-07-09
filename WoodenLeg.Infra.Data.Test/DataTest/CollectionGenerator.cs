using System.Collections.Generic;
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
        public IEnumerable<Player> GeneratePlayerCollection(int numberOfInstances)
        {
            CollectionName = "Player";
            List<Player> _playerList = new List<Player>();

            for ( int i = 0; i < numberOfInstances; i++ )
            {
                _playerList.Add( new Player { Id = i, Name = $"Player{i}", Team = $"Team{i}" } );
            }

            return _playerList;
        }

        #endregion
    }
}
