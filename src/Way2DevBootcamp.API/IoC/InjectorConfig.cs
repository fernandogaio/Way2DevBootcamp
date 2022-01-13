using Microsoft.EntityFrameworkCore;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Data.Repositories;
using Way2DevBootcamp.Data.Transaction;
using Way2DevBootcamp.Domain.Interfaces;
using Way2DevBootcamp.Domain.Services;

namespace Way2DevBootcamp.API.IoC {
    public static class NativeInjectorConfig {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
