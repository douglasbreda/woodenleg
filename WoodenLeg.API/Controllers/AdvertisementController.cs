using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WoodenLeg.Application.Interfaces;
using WoodenLeg.Domain.Entities;

namespace WoodenLeg.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        #region [Properties]

        private readonly IAdvertisementAppService _adAppService;

        #endregion

        public AdvertisementController( IAdvertisementAppService advertisementAppService )
        {
            _adAppService = advertisementAppService;
        }

        #region [Methods]

        [HttpGet]
        public IEnumerable<Advertisement> Get()
        {
            return _adAppService.Get();
        }

        [HttpGet( "{id}" )]
        public Advertisement GetById( string id )
        {
            return _adAppService.GetById( id );
        }

        [HttpPost]
        public async Task<string> Post( [FromBody] Advertisement ad )
        {
            return await _adAppService.Create( ad );
        }

        [HttpPut]
        public async Task<ActionResult> Update( [FromBody] Advertisement ad )
        {
            bool _result = await _adAppService.Update( ad );

            if ( _result )
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete( Advertisement ad )
        {
            bool _result = await _adAppService.Delete( ad );

            if ( _result )
                return Ok();
            else
                return BadRequest();
        }

        #endregion
    }
}