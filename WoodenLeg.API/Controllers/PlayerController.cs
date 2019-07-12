using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Infra.Data.Data;

namespace WoodenLeg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        #region [Attributes]

        private readonly IMongoAccess _mongoAccess;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mongoAccess"></param>
        public PlayerController( IMongoAccess mongoAccess )
        {
            _mongoAccess = mongoAccess;
        }

        #endregion

        #region [Methods]

        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            return _mongoAccess.GetCollection<Player>( nameof( Player ) )
                               .Find( Builders<Player>.Filter.Empty ).ToList();
        }

        #endregion

    }
}