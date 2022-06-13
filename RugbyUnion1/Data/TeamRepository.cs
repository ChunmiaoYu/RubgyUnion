using RugbyClub1.Models;

namespace RugbyUnion1.Data
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
