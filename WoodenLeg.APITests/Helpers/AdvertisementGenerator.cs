using System;
using System.Collections.Generic;
using WoodenLeg.CrossCutting.Helpers;
using WoodenLeg.Domain.Entities;

namespace WoodenLeg.APITests.Helpers
{
    public class AdvertisementGenerator
    {
        #region [Methods]

        /// <summary>
        /// Generate a list of advertisements for tests
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<Advertisement> GenerateAds(int number )
        {
            List<Advertisement> _ads = new List<Advertisement>();

            for ( int i = 0; i < number; i++ )
            {
                _ads.Add( GenerateSingleAd( $"Ad nº {i + 1}" ) );
            }

            return _ads;
        }

        /// <summary>
        /// Generate a single advertisement
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public Advertisement GenerateSingleAd( string description = "" )
        {
            return new Advertisement
            {
                Id = Guid.NewGuid().ToString(),
                Description = description.HasValue() ? description : "ad test",
                Player = new Player
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "player for sell",
                    Team = "Any team"
                },
                Price = 10
            };
        }

        #endregion
    }
}
