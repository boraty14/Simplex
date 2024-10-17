using Cysharp.Threading.Tasks;
using Game.Scripts.Core.GameTask;
using Game.Scripts.Scopes.Main;
using Game.Scripts.Scopes.Root.Components;
using Game.Scripts.Scopes.Root.Services;
using UnityEngine.SceneManagement;
using VContainer;

namespace Game.Scripts.Scopes.Root.GameTasks
{
    public class RestartGameTask : GameTaskBase
    {
        private readonly SceneLoadService _sceneLoadService;
        private readonly DynamicLoadService _dynamicLoadService;
        private readonly GameTaskService _gameTaskService;
        private readonly ScopeLoadService _scopeLoadService;
        private readonly RootPanelParent _rootPanelParent;

        [Inject]
        public RestartGameTask(SceneLoadService sceneLoadService, DynamicLoadService dynamicLoadService,
            GameTaskService gameTaskService, ScopeLoadService scopeLoadService, RootPanelParent rootPanelParent)
        {
            _sceneLoadService = sceneLoadService;
            _dynamicLoadService = dynamicLoadService;
            _gameTaskService = gameTaskService;
            _scopeLoadService = scopeLoadService;
            _rootPanelParent = rootPanelParent;
        }

        public override async UniTask Run()
        {
            // do not touch order
            await _rootPanelParent.loadingPanel.Show(true);
            _gameTaskService.ClearTasks();
            _dynamicLoadService.ReleaseLoadedObjects();
            _scopeLoadService.Reset();
            _sceneLoadService.Reset();
            SceneManager.LoadScene(0);
            _scopeLoadService.LoadScope<MainScope>();
        }
    }
}