using RugbyClub1.Models;

namespace RugbyUnion1.Data
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
