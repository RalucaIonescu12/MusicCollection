﻿using MusicCollection.Helpers.Jwt;
using MusicCollection.Repositories.AccountRepository;
using MusicCollection.Repositories.ArtistRepository;
using MusicCollection.Repositories.PlaylistRepository;
using MusicCollection.Repositories.SongRepository;
using MusicCollection.Services.AccountService;
using MusicCollection.Services.ArtistService;
using MusicCollection.Services.PlaylistService;
using MusicCollection.Services.SongService;

namespace MusicCollection.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IPlaylistRepository, PlaylistRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISongService, SongService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IPlaylistService, PlaylistService>();
            services.AddTransient<IArtistService, ArtistService>();
            return services;
        }

        //public static IServiceCollection AddSeeders(this IServiceCollection services)
        //{
        //    services.AddTransient<StudentsSeeder>();

        //    return services;
        //}

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
