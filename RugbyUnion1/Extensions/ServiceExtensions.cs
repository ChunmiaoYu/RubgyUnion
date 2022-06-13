using RugbyUnion1.Data;
using Microsoft.EntityFrameworkCore;

namespace RugbyUnion1.Extensions
{//App setting
    public static class ServiceExtensions
    {
        public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["sqlconnection:connectionString"];

            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }
        public static void ConfigureRepository(this IServiceCollection services)
        {//regist for the repository service
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();

        }
    }
}
