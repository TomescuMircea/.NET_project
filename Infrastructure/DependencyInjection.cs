using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IGenericEntityRepository<Estate>, EstateRepository>();
            services.AddScoped<IGenericEntityRepository<Image>, ImageRepository>();
            services.AddScoped<IGenericEntityRepository<House>, HouseRepository>();
            services.AddScoped<IGenericEntityRepository<Favorite>, FavoriteRepository>();
            services.AddScoped<IGenericEntityRepository<User>, UserRepository>();
            services.AddScoped<IGenericEntityRepository<Pay>, PayRepository>();
            services.AddScoped<IGenericEntityRepository<Apartment>, ApartmentRepository>();
            services.AddScoped<IGenericEntityRepository<BusinessSpace>, BusinessSpaceRepository>();
            services.AddScoped<IGenericEntityRepository<Contact>, ContactRepository>();
            services.AddScoped<IGenericEntityRepository<Report>, ReportRepository>();
            services.AddScoped<IGenericEntityRepository<ReviewProperty>, ReviewPropertyRepository>();
            services.AddScoped<IGenericEntityRepository<ReviewUser>, ReviewUserRepository>();









            return services;
        }
    }
}
