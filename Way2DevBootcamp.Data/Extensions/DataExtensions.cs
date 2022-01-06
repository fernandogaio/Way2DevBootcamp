using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Data.Repositories;
using Way2DevBootcamp.Data.Transaction;
using Way2DevBootcamp.Domain.Interfaces;

namespace Way2DevBootcamp.Data.Extensions {
    public static class DataExtensions {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
