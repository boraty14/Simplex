using Dummy;
using Game.Scripts.Gameplay;
using Game.Scripts.GameTask;
using Game.Scripts.Memory;
using Game.Scripts.Panel;
using Game.Scripts.Scene;
using Game.Scripts.Scopes.Root.Components;
using Game.Scripts.Unit;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Root
{
    public class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // services
            builder.Register<GameTaskRunner>(Lifetime.Singleton);
            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<PanelManager>(Lifetime.Singleton);
            builder.Register<DynamicLoader>(Lifetime.Singleton);
            builder.Register<GameStateData>(Lifetime.Singleton);
            
            // units
            builder.Register<UnitManager<DummyUnit>>(Lifetime.Singleton);

            // components
            builder.RegisterComponent(FindAnyObjectByType<PanelParent>());
            builder.RegisterComponent(FindAnyObjectByType<RootUICamera>());
            builder.RegisterComponentOnNewGameObject<UnitParent>(Lifetime.Singleton, "UnitParent");
            
            // entry points
            builder.RegisterEntryPoint<GameRunner>();
        }
    }
}

// unitask update loop -> stop task
// idisposable for systems
// add messagepipe,r3