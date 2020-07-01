using Microsoft.Extensions.DependencyInjection;

namespace Tulkas.Core.Helpers.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
