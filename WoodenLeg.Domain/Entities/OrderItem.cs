using WoodenLeg.Domain.Interfaces.Entities;

namespace WoodenLeg.Domain.Entities
{
    public class OrderItem : IEntityBase
    {
        #region [Properties]

        public string Id { get; set; }

        public Player Player { get; set; }

        public double Price { get; set; }

        #endregion
    }
}
