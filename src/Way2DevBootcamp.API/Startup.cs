using FluentValidation;
using Way2DevBootcamp.API.Extensions;
using Way2DevBootcamp.API.IoC;
using Way2DevBootcamp.Domain.Validators;

namespace Way2DevBootcamp.API;
public class Startup {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services) {
        services.AddCors();
        services.AddControllers();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddSwagger();
        services.AddMediatR();
        services.AddAuthentication(Configuration);
        services.AddAuthorizationPolicies();
        services.AddAutoMapper(typeof(Startup));
        services.RegisterServices(Configuration);
    }

    public void Configure(WebApplication app, IWebHostEnvironment env) {
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors(builder => builder
            .SetIsOriginAllowed(orign => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
        app.MapControllers();
    }
}