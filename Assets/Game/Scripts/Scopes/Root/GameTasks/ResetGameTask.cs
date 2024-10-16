using Cysharp.Threading.Tasks;
using Game.Scripts.Core;
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
        private readonly GameTaskService _gameTaskService;
        private readonly ScopeLoadService _scopeLoadService;

        [Inject]
        public ResetGameTask(SceneLoadService sceneLoadService, DynamicLoadService dynamicLoadService,
            GameTaskService gameTaskService, ScopeLoadService scopeLoadService)
        {
            _sceneLoadService = sceneLoadService;
            _dynamicLoadService = dynamicLoadService;
            _gameTaskService = gameTaskService;
            _scopeLoadService = scopeLoadService;
        }

        public override UniTask Run()
        {
            // do not touch order

            _gameTaskService.ClearTasks();
            _dynamicLoadService.ReleaseLoadedObjects();
            _scopeLoadService.Reset();
            _sceneLoadService.Reset();
            SceneManager.LoadScene(0);
            _scopeLoadService.LoadScope<MainScope>();
            return UniTask.CompletedTask;
        }
    }
}