using Dummy;
using Game.Scripts.Panel;
using Game.Scripts.Scopes.Main.EntryPoints;
using Game.Scripts.Scopes.Main.GameTasks;
using Game.Scripts.Scopes.Root.Components;
using Game.Scripts.Unit;
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
            
            // units
            builder.Register<UnitManager<DummyUnit>>(Lifetime.Scoped);
            
            // entry points
            builder.RegisterEntryPoint<MainRunner>(Lifetime.Scoped);
            
            // game tasks
            builder.Register<TogglePanelsGameTask>(Lifetime.Transient);
        }
    }
}