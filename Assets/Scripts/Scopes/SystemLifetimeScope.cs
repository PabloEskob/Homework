using AssetManagement;
using Data;
using Factory;
using Infrastructure;
using PersistentProgress;
using Spawner;
using StaticData;
using Units;
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
            builder.Register<PersistentProgressService>(Lifetime.Singleton).As<IPersistentProgressService>();
            builder.Register<SaveLoadService>(Lifetime.Singleton).As<ISaveLoadService>();
            builder.Register<WorldProgress>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<SpawnerUnits>();
            builder.RegisterComponentInHierarchy<SaveLoadSystem>();
            builder.Register<UnitSaveLoadManager>(Lifetime.Singleton);
            builder.Register<LoadLevel>(Lifetime.Singleton);
        }
    }
}