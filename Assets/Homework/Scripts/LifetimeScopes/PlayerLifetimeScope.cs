using Homework.Scripts.Components;
using Homework.Scripts.Controllers;
using Homework.Scripts.Input;
using Homework.Scripts.Models.Player;
using VContainer;
using VContainer.Unity;

namespace Homework.Scripts.LifetimeScopes
{
    public class PlayerLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameInput>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<InputModule>();
            builder.RegisterComponentInHierarchy<PlayerModel>();
            builder.RegisterEntryPoint<PlayerMoveController>();
            builder.RegisterEntryPoint<PlayerRotateController>();
            builder.RegisterEntryPoint<TakeDamageComponent>();
        }
    }
}