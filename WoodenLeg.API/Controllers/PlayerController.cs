using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WoodenLeg.Application.Interfaces;
using WoodenLeg.Domain.Entities;

namespace WoodenLeg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        #region [Attributes]

        private readonly IPlayerAppService _playerAppService;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mongoAccess"></param>
        public PlayerController( IPlayerAppService playerAppService )
        {
            _playerAppService = playerAppService;
        }

        #endregion

        #region [Methods]

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _playerAppService.Get();
        }

        [HttpGet( "{id}" )]
        public Player GetById( string id )
        {
            return _playerAppService.GetById( id );
        }

        [HttpPost]
        public async Task<string> Post( [FromBody] Player player )
        {
            return await _playerAppService.Create( player );
        }

        [HttpPut]
        public async Task<ActionResult> Update( [FromBody] Player player )
        {
            bool _result = await _playerAppService.Update( player );

            if ( _result )
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete( Player player )
        {
            bool _result = await _playerAppService.Delete( player );

            if ( _result )
                return Ok();
            else
                return BadRequest();
        }
        
        #endregion

    }
}