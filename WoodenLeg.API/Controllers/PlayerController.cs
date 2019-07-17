using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Infra.Data.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public IEnumerable<Player> Get()
        {
            return _mongoAccess.GetCollection<Player>( nameof( Player ) )
                               .Find( Builders<Player>.Filter.Empty ).ToList();
        }

        [HttpGet( "{id}" )]
        public Player GetById( string id )
        {
            var query = Builders<Player>.Filter.Eq( "_id", id );

            return _mongoAccess.GetCollection<Player>( nameof( Player ) )
                               .Find( query ).FirstOrDefault();
        }

        [HttpPost]
        public async Task<string> Post( [FromBody] Player player )
        {
            if ( player != null )
            {
                try
                {
                    await _mongoAccess.InsertOne( _mongoAccess.GetCollection<Player>( nameof( Player ) ), player );
                    return "";
                }
                catch ( MongoException ex )
                {
                    return ex.ToString();
                }
            }

            return "The player is null";
        }

        #endregion

    }
}