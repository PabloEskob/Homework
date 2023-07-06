using AssetManagement;
using Data;
using Factory;
using Infrastructure;
using Other;
using PersistentProgress;
using Spawner;
using StaticData;
using UnityEngine;
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
            builder.RegisterFactory<UnitObject, Vector3, UnitObject>(container =>
            {
                return (go, vector3) =>
                {
                    UnitObject unitObject = container.Instantiate(go, vector3, Quaternion.identity);
                    return unitObject;
                };
            }, Lifetime.Singleton);
            
            builder.Register<WorldProgress>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<SpawnerUnits>();
            builder.RegisterComponentInHierarchy<SaveLoadSystem>();
        }
    }
}