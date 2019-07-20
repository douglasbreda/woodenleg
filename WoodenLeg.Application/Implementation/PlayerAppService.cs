using WoodenLeg.Application.Interfaces;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Application.Implementation
{
    public class PlayerAppService : AppServiceBase<Player>, IPlayerAppService
    {
        public PlayerAppService( IPlayerService appServiceBase ) : base( appServiceBase ) { }
    }
}
