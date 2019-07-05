using System;
using System.Collections.Generic;
using System.Text;
using WoodenLeg.Domain.Entities;
using WoodenLeg.Domain.Interfaces.Repositories;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Domain.Services
{
    public class PlayerService : ServiceBase<Player>, IPlayerService
    {
        #region [Constructor]

        public PlayerService( IRepositoryBase<Player> repositoryBase ) : base( repositoryBase )
        {
        }

        #endregion
    }
}
