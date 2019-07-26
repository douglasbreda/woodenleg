using System;
using System.Collections.Generic;
using System.Text;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Domain.Interfaces.Repositories;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Domain.Services
{
    public class AdvertisementService : ServiceBase<Advertisement>, IAdvertisementService
    {
        public AdvertisementService( IRepositoryBase<Advertisement> repositoryBase )
            : base( repositoryBase ) { }
    }
}
