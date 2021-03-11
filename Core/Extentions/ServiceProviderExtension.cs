using System;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extentions
{
    public static class ServiceProviderExtension
    {
       public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceProvider,ICoreModule[] coreModules)
        {
            foreach (var coreModule in coreModules)
            {
                coreModule.Load(serviceProvider);
            }
            return ServiceTool.Create(serviceProvider);
        }
    }
}
