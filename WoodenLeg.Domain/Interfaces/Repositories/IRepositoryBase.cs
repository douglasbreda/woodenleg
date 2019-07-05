using System;
using System.Collections.Generic;
using System.Text;

namespace WoodenLeg.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        #region [Definitions]

        void Create( TEntity entity );

        void Edit( TEntity entity );

        void Delete( TEntity entity );

        void Dispose();

        #endregion
    }
}
