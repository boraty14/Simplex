using Game.Scripts.Scopes.Root.Components;
using Game.Scripts.Scopes.Root.EntryPoints;
using Game.Scripts.Scopes.Root.GameTasks;
using Game.Scripts.Scopes.Root.Services;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Root
{
    public class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // services
            builder.Register<GameTaskService>(Lifetime.Singleton);
            builder.Register<SceneLoadService>(Lifetime.Singleton);
            builder.Register<DynamicLoadService>(Lifetime.Singleton);
            builder.Register<ScopeLoadService>(Lifetime.Singleton);

            // components
            builder.RegisterComponentInHierarchy<RootUICamera>();
            builder.RegisterComponentInHierarchy<GameCamera>();
            
            // game tasks
            builder.Register<ResetGameTask>(Lifetime.Transient);
            
            // entry points
            builder.RegisterEntryPoint<RootRunner>(Lifetime.Singleton);
            
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
        }
    }
}

// add messagepipe,r3
