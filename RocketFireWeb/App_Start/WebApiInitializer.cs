using SimpleInjector;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using RocketFireWeb.Repositories;
using RocketFireWeb.Converters;
using EarthFire.Data;
using EarthFire.Data.Repositories;

namespace RocketFireWeb
{
  public static class WebApiInitializer
  {
    public static void Initialize(HttpConfiguration config)
    {
      var container = new Container();
      container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

      InitializeContainer(container);

      container.RegisterWebApiControllers(config);

      container.Verify();

      config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
    }

    private static void InitializeContainer(Container container)
    {
      container.Register<EarthFireContext>(() => new EarthFireContext("name=DefaultConnection"), Lifestyle.Singleton);

      container.Register<IEvacuationPointRepository, EvacuationPointRepository>();
      container.Register<IEvacuationPointConverter, EvacuationPointConverter>();

      container.Register<IFirePointRepository, FirePointRepository>();
      container.Register<IFireLocationConverter, FireLocationConverter>();
    }
  }
}