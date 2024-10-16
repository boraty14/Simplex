using Game.Scripts.Scopes.Main;
using Game.Scripts.Scopes.Root.Services;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Root.EntryPoints
{
    public class RootRunner : IStartable
    {
        private readonly ScopeLoadService _scopeLoadService;

        [Inject]
        public RootRunner(ScopeLoadService scopeLoadService)
        {
            _scopeLoadService = scopeLoadService;
        }
        
        public void Start()
        {
            _scopeLoadService.LoadScope<MainScope>();
        }
    }
}