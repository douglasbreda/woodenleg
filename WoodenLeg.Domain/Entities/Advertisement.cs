using WoodenLeg.Domain.Interfaces.Entities;

namespace WoodenLeg.Domain.Entities
{
    public class Advertisement : IEntityBase
    {
        #region [Properties]

        public string Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public Player Player { get; set; }

        #endregion
    }
}
