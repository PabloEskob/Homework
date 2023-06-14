using Homework.Homework_v2.Scripts.Components;
using Homework.Homework_v2.Scripts.GameManager;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<DeathComponent>();
        builder.Register<GameManager>(Lifetime.Singleton);
    }
}
