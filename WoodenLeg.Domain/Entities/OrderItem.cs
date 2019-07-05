namespace WoodenLeg.Domain.Entities
{
    public class OrderItem
    {
        #region [Properties]

        public int Id { get; set; }

        public Player Player { get; set; }

        public double Price { get; set; }

        #endregion
    }
}
