using WoodenLeg.Domain.Interfaces.Entities;

namespace WoodenLeg.Domain.Entities
{
    public class Player : IEntityBase
    {
        #region [Properties]

        public string Id { get; set; }

        public string Name { get; set; }

        public string Team { get; set; }

        #endregion
    }
}
