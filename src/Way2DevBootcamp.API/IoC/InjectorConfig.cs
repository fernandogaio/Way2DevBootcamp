using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Way2DevBootcamp.Application.Core;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Data.Repositories;
using Way2DevBootcamp.Data.Transaction;
using Way2DevBootcamp.Domain.Interfaces;
using Way2DevBootcamp.Identity.Data;
using Way2DevBootcamp.Identity.Interfaces;
using Way2DevBootcamp.Identity.Services;

namespace Way2DevBootcamp.API.IoC;
public static class InjectorConfig {
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration) {
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddDbContext<IdentityDataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityDataContext>()
            .AddDefaultTokenProviders();

        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<ICategoriaRepository, CategoriaRepository>();
        services.AddScoped<IIdentityService, IdentityService>();
    }
}