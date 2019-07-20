using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WoodenLeg.CrossCutting.Helpers;
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

        /// <summary>
        /// Returns a player collection
        /// </summary>
        /// <returns></returns>
        private IMongoCollection<Player> GetCollection()
        {
            return _mongoAccess.GetCollection<Player>( nameof( Player ) );
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return GetCollection().Find( Builders<Player>.Filter.Empty ).ToList();
        }

        [HttpGet( "{id}" )]
        public Player GetById( string id )
        {
            var query = Builders<Player>.Filter.Eq( "_id", id );

            return GetCollection().Find( query ).FirstOrDefault();
        }

        [HttpPost]
        public async Task<string> Post( [FromBody] Player player )
        {
            if ( player != null )
            {
                try
                {
                    await _mongoAccess.InsertOne( GetCollection(), player );
                    return "";
                }
                catch ( MongoException ex )
                {
                    return ex.ToString();
                }
            }

            return "The player is null";
        }

        [HttpPut]
        public async Task<ActionResult> Update( [FromBody] Player player )
        {
            ReplaceOneResult updateResult = null;
            if ( player != null )
            {
                var filterDefinition = Builders<Player>.Filter.Eq( "_id", player.Id );
                updateResult = await _mongoAccess.Update( GetCollection(), player, filterDefinition );
            }

            if ( updateResult.IsAcknowledged )
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete( string id )
        {
            DeleteResult deleteResult = null;

            if ( id.HasValue() )
                deleteResult = await _mongoAccess.Delete( GetCollection(), id );

            if ( deleteResult.IsAcknowledged )
                return Ok();
            else
                return BadRequest();
        }
        
        #endregion

    }
}