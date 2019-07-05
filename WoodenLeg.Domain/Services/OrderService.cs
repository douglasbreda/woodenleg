using WoodenLeg.Domain.Entities;
using WoodenLeg.Domain.Interfaces.Repositories;
using WoodenLeg.Domain.Interfaces.Services;

namespace WoodenLeg.Domain.Services
{
    public class OrderService : ServiceBase<Order>, IOrderService
    {
        #region [Constructor]

        public OrderService( IRepositoryBase<Order> repositoryBase ) : base( repositoryBase )
        {
        }

        #endregion
    }
}
