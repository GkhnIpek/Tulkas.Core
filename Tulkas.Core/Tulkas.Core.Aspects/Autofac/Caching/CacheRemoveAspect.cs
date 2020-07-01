using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Tulkas.Core.CrossCuttingConcerns.Caching;
using Tulkas.Core.Helpers.Utilities.Interceptors;
using Tulkas.Core.Helpers.Utilities.IoC;

namespace Tulkas.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
