using Homework.Scripts.Controllers;
using Homework.Scripts.Input;
using Homework.Scripts.Models;
using VContainer;
using VContainer.Unity;

namespace Homework.Scripts.LifetimeScopes
{
    public class PlayerLifetimeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameInput>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<InputModule>();
            builder.RegisterEntryPoint<PlayerMoveController>();
            builder.RegisterComponentInHierarchy<PlayerModel>();
            builder.RegisterEntryPoint<PlayerRotateController>();
        }
    }
}