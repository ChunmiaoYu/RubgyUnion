using RugbyUnion1.Data;
using Microsoft.EntityFrameworkCore;

namespace RugbyUnion1.Extensions
{//App setting
    public static class ServiceExtensions
    {//define a method "ConfigureMsSqlContext" for type "IServiceCollection"
        public static void ConfigureMsSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["sqlconnection:connectionString"];

            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }
        //define a method "ConfigureRepository" for type "IServiceCollection"
        public static void ConfigureRepository(this IServiceCollection services)
        {//regist for the repository service
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();

        }
    }
}
