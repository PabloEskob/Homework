using AssetManagement;
using Factory;
using Spawner;
using StaticData;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class SystemLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<AssetProvider>(Lifetime.Singleton).As<IAssetProvider>();
            builder.Register<GameFactory>(Lifetime.Singleton).As<IGameFactory>();
            builder.Register<StaticDataService>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<SpawnerUnits>();
        }
    }
}