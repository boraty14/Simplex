using Game.Scripts.Unit;
using VContainer;
using VContainer.Unity;

namespace Dummy
{
    public class DummyScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<UnitManager<DUnit>>(Lifetime.Singleton);
            
            builder.RegisterEntryPoint<DummyRunner>();
        }
    }
}