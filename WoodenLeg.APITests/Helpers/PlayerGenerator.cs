using System;
using System.Collections.Generic;
using WoodenLeg.CrossCutting.Helpers;
using WoodenLeg.Domain.Entities;

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
        public List<Player> InsertPlayersForTest( int instances )
        {
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

            return _playerList;
        }

        /// <summary>
        /// Returns a single player with optional parameters for name and team name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="teamName"></param>
        /// <returns></returns>
        public Player GetSinglePlayer( string name = "", string teamName = "" )
        {
            return new Player
            {
                Id = Guid.NewGuid().ToString(),
                Name = name.HasValue() ? name : "Player Test da Silva",
                Team = teamName.HasValue() ? teamName : "Team Test"
            };
        }

        #endregion
    }
}
