using Microsoft.Extensions.DependencyInjection;
using Musicalog.Domain.Interfaces.Repository;
using Musicalog.Infraestructure.Repositories;

namespace Musicalog.CrossCutting
{
    public static class InjectionRepositories
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAlbumRepository, AlbumRepository>();
        }
    }
}