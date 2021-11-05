using Microsoft.Extensions.DependencyInjection;
using Musicalog.Application.Services;
using Musicalog.Domain.Interfaces.Application;

namespace Musicalog.CrossCutting
{
    public static class InjectionServices
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IAlbumService, AlbumService>();
        }
    }
}
