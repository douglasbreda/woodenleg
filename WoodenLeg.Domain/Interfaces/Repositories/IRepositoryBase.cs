using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoodenLeg.Domain.Interfaces.Entities;

namespace WoodenLeg.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class, IEntityBase
    {
        #region [Definitions]

        IEnumerable<TEntity> Get();

        TEntity GetById( string id );

        Task<string> Create( TEntity entity );

        Task<bool> Update( TEntity entity );

        Task<bool> Delete( TEntity entity );

        void Dispose();

        #endregion
    }
}
