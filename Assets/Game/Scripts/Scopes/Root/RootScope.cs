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
            builder.RegisterComponentInHierarchy<RootPanelParent>();

            // entry points
            builder.RegisterEntryPoint<RootRunner>(Lifetime.Singleton);
            
            // game tasks
            builder.Register<RestartGameTask>(Lifetime.Transient);

            // RegisterMessagePipe returns options.
            var options = builder.RegisterMessagePipe( /* configure option */);
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));

            // message pipe events
            //builder.RegisterMessageBroker<DummyEvent>(options);
        }
    }
}

/*
 * VContainer
 * UniTask
 * MessagePipe
 * R3
 * ObservableCollections-R3
 * ZString
 */