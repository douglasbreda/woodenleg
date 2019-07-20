using System.Collections.Generic;
using WoodenLeg.Domain.Interfaces.Entities;

namespace WoodenLeg.Domain.Entities
{
    public class Order : IEntityBase
    {
        #region [Propriedades]

        public string Id { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }

        public double Total { get; set; }

        #endregion
    }
}
