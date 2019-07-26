using WoodenLeg.Domain.Interfaces.Entities;

namespace WoodenLeg.Infra.Data.Test.DataTest
{
    /// <summary>
    /// Entity used to realize tests in a fake database
    /// </summary>
    public class TestEntity : IEntityBase
    {
        #region [Properties]

        public string Id { get; set; }

        public string Description { get; set; }

        #endregion

    }
}
