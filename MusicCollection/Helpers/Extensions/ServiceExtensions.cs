using MusicCollection.Repositories.AccountRepository;
using MusicCollection.Repositories.SongRepository;
using MusicCollection.Services.AccountService;
using MusicCollection.Services.SongService;

namespace MusicCollection.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
           
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISongService, SongService>();
            services.AddTransient<IAccountService, AccountService>();

            return services;
        }

        //public static IServiceCollection AddSeeders(this IServiceCollection services)
        //{
        //    services.AddTransient<StudentsSeeder>();

        //    return services;
        //}

        //public static IServiceCollection AddUtils(this IServiceCollection services)
        //{
        //    services.AddTransient<IJwtUtils, JwtUtils>();

        //    return services;
        //}
    }
}
