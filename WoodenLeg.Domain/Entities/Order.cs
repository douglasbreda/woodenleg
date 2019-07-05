using System.Collections.Generic;

namespace WoodenLeg.Domain.Entities
{
    public class Order
    {
        #region [Propriedades]

        public int Id { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }

        public double Total { get; set; }

        #endregion
    }
}
