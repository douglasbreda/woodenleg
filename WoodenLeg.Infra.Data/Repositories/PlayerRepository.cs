using WoodenLeg.Domain.Entities;
using WoodenLeg.Domain.Interfaces.Repositories;

namespace WoodenLeg.Infra.Data.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
    }
}
