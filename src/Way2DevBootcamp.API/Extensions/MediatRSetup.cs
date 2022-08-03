using FluentValidation;
using MediatR;
using Way2DevBootcamp.Application.Core;

namespace Way2DevBootcamp.API.Extensions {
    public static class MediatRSetup {
        public static void AddMediatR(this IServiceCollection services) {
            var assembly = AppDomain.CurrentDomain.Load("Way2DevBootcamp.Application");
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationRequestBehavior<,>));
            services.AddMediatR(assembly);
        }
    }
}
