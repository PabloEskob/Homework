using Homework.Homework_v2.Scripts.Bullets;
using Homework.Homework_v2.Scripts.Components;
using Homework.Homework_v2.Scripts.Enemy;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Homework.Homework_v2.Scripts.LifetimeScopes
{
    public class BulletLifetimeScope : LifetimeScope
    {
        [SerializeField] private BulletConfig _bulletConfig;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<WeaponComponent>().AsSelf();
            builder.RegisterComponentInHierarchy<BulletSystem>().AsSelf();
            builder.RegisterInstance(_bulletConfig);
            builder.RegisterComponentInHierarchy<EnemyPool>();
            builder.RegisterComponentInHierarchy<EnemyManager>();
            builder.RegisterComponentInHierarchy<EnemySpawner>();

            builder.RegisterFactory<EnemyFireComponent, Transform, EnemyFireComponent>(container =>
            {
                return (e, t) =>
                {
                    var enemy = container.Instantiate(e, t);
                    return enemy;
                };
            }, Lifetime.Singleton);
        }
    }
}