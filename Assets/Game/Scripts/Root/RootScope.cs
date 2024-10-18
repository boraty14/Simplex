using Game.Scripts.Components;
using Game.Scripts.Sound;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Root
{
    public class RootScope : LifetimeScope
    {
        [SerializeField] private SoundSettings _soundSettings;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // services
            builder.Register<SoundService>(Lifetime.Singleton);

            // components
            builder.RegisterComponentInHierarchy<RootLoadingScreen>();
            builder.RegisterComponentInHierarchy<SoundParent>();
            
            // scriptable objects - settings
            builder.RegisterInstance(_soundSettings);
            
            //helpers
            builder.Register<SoundBuilder>(Lifetime.Transient);
        }
    }
}