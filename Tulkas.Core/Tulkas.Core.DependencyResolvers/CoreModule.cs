using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Tulkas.Core.CrossCuttingConcerns.Caching;
using Tulkas.Core.CrossCuttingConcerns.Caching.Microsoft;
using Tulkas.Core.Helpers.Utilities.IoC;

namespace Tulkas.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
