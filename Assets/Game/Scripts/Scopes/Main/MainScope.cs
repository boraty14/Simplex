using Game.Scripts.Core.Panel;
using Game.Scripts.Core.Unit;
using Game.Scripts.Dummy;
using Game.Scripts.Scopes.Main.EntryPoints;
using Game.Scripts.Scopes.Main.GameTasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Main
{
    public class MainScope : LifetimeScope
    {
        [SerializeField] private PanelParent _panelParentPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            
            // services
            builder.Register<PanelManager>(Lifetime.Scoped);
            
            // components
            builder.RegisterComponentInNewPrefab(_panelParentPrefab, Lifetime.Scoped)
                .UnderTransform(transform);
            builder.RegisterComponentOnNewGameObject<UnitParent>(Lifetime.Scoped, "UnitParent")
                .UnderTransform(transform);
            
            // entry points
            builder.RegisterEntryPoint<MainRunner>(Lifetime.Scoped);
            builder.RegisterEntryPoint<DummySubscriber>(Lifetime.Scoped);
            builder.RegisterEntryPoint<DummyPublisher>(Lifetime.Scoped);
            
            // game tasks
            builder.Register<WaitBeforeRestartGameTask>(Lifetime.Transient);
        }
    }
}