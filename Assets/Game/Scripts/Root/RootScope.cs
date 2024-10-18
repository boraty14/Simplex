using Game.Scripts.Components;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Root
{
    public class RootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<RootLoadingScreen>();
        }
    }
}