namespace Way2DevBootcamp.API.Extensions;

public static class WebApplicationBuilderExtensions {
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder) {
        var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration) as Startup;
        startup.ConfigureServices(builder.Services);
        
        var app = builder.Build();
        startup.Configure(app, app.Environment);
        app.Run();

        return builder;
    }
}