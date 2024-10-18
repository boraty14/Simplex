using Game.Scripts.Components;
using Game.Scripts.GameTask;
using Game.Scripts.Memory;
using Game.Scripts.Panel;
using Game.Scripts.Sound;
using Game.Scripts.Unit;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Main
{
    public class MainScope : LifetimeScope
    {

        protected override void Configure(IContainerBuilder builder)
        {
            // services
            builder.Register<GameTaskService>(Lifetime.Singleton);
            builder.Register<SceneLoadService>(Lifetime.Singleton);
            builder.Register<DynamicLoadService>(Lifetime.Singleton);
            builder.Register<PanelService>(Lifetime.Singleton);

            // components
            builder.RegisterComponentInHierarchy<GameUICamera>();
            builder.RegisterComponentInHierarchy<GameCamera>();
            builder.RegisterComponentInHierarchy<PanelParent>();
            builder.RegisterComponentOnNewGameObject<UnitParent>(Lifetime.Scoped, "UnitParent")
                .UnderTransform(transform);

            // entry points
            builder.RegisterEntryPoint<MainRunner>();

            // game tasks
            builder.Register<RestartGameTask>(Lifetime.Transient);
            builder.Register<StartGameTask>(Lifetime.Transient);

            // RegisterMessagePipe returns options.
            builder.RegisterMessagePipe();
            // Setup GlobalMessagePipe to enable diagnostics window and global function
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
        }
    }
}