﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIMA.Universitas.Application.Interfaces.CacheRepositories;
using SIMA.Universitas.Application.Interfaces.Contexts;
using SIMA.Universitas.Application.Interfaces.Repositories;
using SIMA.Universitas.Infrastructure.CacheRepositories;
using SIMA.Universitas.Infrastructure.DbContexts;
using SIMA.Universitas.Infrastructure.Repositories;

namespace SIMA.Universitas.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion Repositories
        }
    }
}