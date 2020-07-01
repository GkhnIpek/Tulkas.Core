using Microsoft.Extensions.DependencyInjection;

namespace Tulkas.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
