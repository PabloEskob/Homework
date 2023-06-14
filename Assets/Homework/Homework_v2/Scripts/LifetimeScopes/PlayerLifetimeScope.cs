using Homework.Homework_v2.Scripts.Character.Fire;
using Homework.Homework_v2.Scripts.Character.Move;
using Homework.Homework_v2.Scripts.Components;
using Homework.Homework_v2.Scripts.Input;
using VContainer;
using VContainer.Unity;

namespace Homework.Homework_v2.Scripts.LifetimeScopes
{
    public class PlayerLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<InputModule>().AsSelf();
            builder.Register<InputSystem>(Lifetime.Singleton).AsSelf();
            builder.RegisterComponentInHierarchy<MoveComponent>().As<IMove>();
            builder.RegisterEntryPoint<PlayerMoveController>().AsSelf();
            builder.RegisterComponentInHierarchy<PlayerFireController>();
            builder.Register<FireComponent>(Lifetime.Singleton);
        }
    }
}