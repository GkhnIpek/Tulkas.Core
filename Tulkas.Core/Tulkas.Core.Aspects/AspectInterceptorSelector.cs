using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using Tulkas.Core.Aspects.Autofac.Exception;
using Tulkas.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Tulkas.Core.Helpers.Utilities.Interceptors;

namespace Tulkas.Core.Aspects
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            var methodAttributes =
                type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
