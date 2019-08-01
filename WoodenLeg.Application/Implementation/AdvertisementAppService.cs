using WoodenLeg.Domain.Entities;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Application.Implementation
{
    public class AdvertisementAppService : AppServiceBase<Advertisement>
    {
        public AdvertisementAppService( IServiceBase<Advertisement> appServiceBase )
            : base( appServiceBase ) { }
    }
}
