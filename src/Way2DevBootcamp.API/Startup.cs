using Way2DevBootcamp.API.Extensions;
using Way2DevBootcamp.API.IoC;

namespace Way2DevBootcamp.API {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddSwagger();
            services.AddAutoMapper(typeof(Startup));
            services.RegisterServices(Configuration);
        }

        public void Configure(WebApplication app, IWebHostEnvironment env) {
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
