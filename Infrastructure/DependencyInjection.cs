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

            services.AddScoped<IEstateRepository, EstateRepository>();
            services.AddScoped<ICredentialRepository, CredentialRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IBusinessSpaceRepository, BusinessSpaceRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReviewPropertyRepository, ReviewPropertyRepository>();
            services.AddScoped<IReviewUserRepository, ReviewUserRepository>();









            return services;
        }
    }
}
