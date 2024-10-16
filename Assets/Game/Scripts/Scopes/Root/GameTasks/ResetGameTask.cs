using Cysharp.Threading.Tasks;
using Game.Scripts.GameTask;
using Game.Scripts.Scopes.Main;
using Game.Scripts.Scopes.Root.Services;
using UnityEngine.SceneManagement;
using VContainer;

namespace Game.Scripts.Scopes.Root.GameTasks
{
    public class ResetGameTask : GameTaskBase
    {
        private readonly SceneLoadService _sceneLoadService;
        private readonly DynamicLoadService _dynamicLoadService;
        private readonly GameTaskRunner _gameTaskRunner;
        private readonly ScopeLoadService _scopeLoadService;

        [Inject]
        public ResetGameTask(SceneLoadService sceneLoadService, DynamicLoadService dynamicLoadService,
            GameTaskRunner gameTaskRunner, ScopeLoadService scopeLoadService)
        {
            _sceneLoadService = sceneLoadService;
            _dynamicLoadService = dynamicLoadService;
            _gameTaskRunner = gameTaskRunner;
            _scopeLoadService = scopeLoadService;
        }

        public override UniTask Run()
        {
            // do not touch order

            _gameTaskRunner.ClearTasks();
            _dynamicLoadService.ReleaseLoadedObjects();
            _scopeLoadService.Reset();
            _sceneLoadService.Reset();
            SceneManager.LoadScene(0);
            _scopeLoadService.LoadScope<MainScope>();
            return UniTask.CompletedTask;
        }
    }
}