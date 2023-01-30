using Fake_Store_Data.DataSet;
using Fake_Store_Data.Identity;
using Fake_Store_Data.Repository;
using Fake_Store_Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fake_Store_IOC
{
    public static class DependebcyInjection
    {
        public static IServiceCollection ConfiguraçãoServices(this IServiceCollection Services, IConfiguration Configuration)
        {



            Services.AddDbContext<DbSet>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(Configuration.GetConnectionString("FakeStoreconeccaoDB"),
                    b => b.MigrationsAssembly(typeof(DbSet).Assembly.FullName));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            
            // injeções de dependencia
            Services.AddTransient<IProductRepository, ProdutoRepository>();
            Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            Services.AddScoped<IAuthenticate, AuthenticateService>();


            // iniciar Identity
            Services.AddIdentity<IdentityUser, IdentityRole>()
                        .AddEntityFrameworkStores<DbSet>()
                        .AddDefaultTokenProviders();

            return Services;
        }

       }
}