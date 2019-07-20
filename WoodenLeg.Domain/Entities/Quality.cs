using WoodenLeg.Domain.Interfaces.Entities;

namespace WoodenLeg.Domain.Entities
{
    public class Quality : IEntityBase
    {
        public string Id { get; set; }

        public string Description { get; set; }
    }
}
