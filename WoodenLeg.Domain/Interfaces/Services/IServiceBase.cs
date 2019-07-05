namespace WoodenLeg.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        #region [Definitions]

        void Create( TEntity entity );

        void Edit( TEntity entity );

        void Delete( TEntity entity );

        void Dispose();

        #endregion
    }
}
