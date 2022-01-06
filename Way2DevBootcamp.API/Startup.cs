using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Way2DevBootcamp.Data.Context;
using Way2DevBootcamp.Data.Extensions;
using Way2DevBootcamp.Data.Repositories;
using Way2DevBootcamp.Data.Transaction;
using Way2DevBootcamp.Domain.Interfaces;
using Way2DevBootcamp.Domain.Services;

namespace Way2DevBootcamp.API {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Way2 Dev Bootcamp API", Version = "v1" });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //options.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddEntityFramework(Configuration);
            services.AddRepositories();

            services.AddScoped<IProdutoService, ProdutoService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment) {
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
