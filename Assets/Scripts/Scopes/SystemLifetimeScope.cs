using AssetManagement;
using Factory;
using Infrastructure;
using Repository;
using SaveLoad;
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
            builder.Register<UnitFactory>(Lifetime.Singleton);
            builder.Register<ResourcesFactory>(Lifetime.Singleton);
            builder.Register<StaticDataService>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<Spawner.Spawner>();
            builder.RegisterComponentInHierarchy<SaveLoadSystem>();
            builder.Register<LoadLevel>(Lifetime.Singleton);
            builder.Register<SaveLoadUnit>(Lifetime.Singleton).AsSelf().As<ISaveLoadProgress>();
            builder.Register<SaveLoadResources>(Lifetime.Singleton).AsSelf().As<ISaveLoadProgress>();
            builder.Register<SaveLoadManager>(Lifetime.Singleton);
            builder.Register<GameRepository>(Lifetime.Singleton).AsSelf().As<IGameRepository>();
        }
    }
}