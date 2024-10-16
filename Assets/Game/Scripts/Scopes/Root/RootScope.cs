using Game.Scripts.GameTask;
using Game.Scripts.Memory;
using Game.Scripts.Scene;
using Game.Scripts.Scopes.Root.Components;
using Game.Scripts.Scopes.Root.GameTasks;
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
            builder.Register<DynamicLoader>(Lifetime.Singleton);

            // components
            builder.RegisterComponentInHierarchy<RootUICamera>();

            // game tasks
            builder.Register<ResetGameTask>(Lifetime.Transient);
        }
    }
}

// unitask update loop -> stop task
// idisposable for systems
// add messagepipe,r3
// register to panels that is dynamically created.
// load prefabs as child scopes