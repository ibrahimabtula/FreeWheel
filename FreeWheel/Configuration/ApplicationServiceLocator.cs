using FreeWheel.Domain.Services;
using FreeWheel.Domain.Services.Movies;

namespace FreeWheel.Configuration
{
    public static class ApplicationServiceLocator
    {
        private static readonly StructureMap.Container Container;

        static ApplicationServiceLocator()
        {
            Container = new StructureMap.Container(configuration =>
            {
                configuration.For<IMovieService>().Use<MovieService>().Transient();
            });
        }

        public static T GetService<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
