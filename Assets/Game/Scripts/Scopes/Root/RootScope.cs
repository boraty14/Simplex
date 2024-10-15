using Game.Scripts.Gameplay;
using Game.Scripts.GameTask;
using Game.Scripts.Memory;
using Game.Scripts.Panel;
using Game.Scripts.Scene;
using Game.Scripts.Unit;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Root
{
    public class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<UnitRegistry>(Lifetime.Singleton);
            builder.Register<GameTaskRunner>(Lifetime.Singleton);
            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<PanelHandler>(Lifetime.Singleton);
            builder.Register<DynamicLoader>(Lifetime.Singleton);
            builder.Register<GameStateData>(Lifetime.Singleton);
        }
    }
}