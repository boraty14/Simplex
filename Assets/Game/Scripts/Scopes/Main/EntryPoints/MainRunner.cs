using Cysharp.Threading.Tasks;
using Game.Scripts.Scopes.Main.GameTasks;
using Game.Scripts.Scopes.Root.Components;
using Game.Scripts.Scopes.Root.GameTasks;
using Game.Scripts.Scopes.Root.Services;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Main.EntryPoints
{
    public class MainRunner : IStartable
    {
        private readonly IObjectResolver _container;
        private readonly GameTaskService _gameTaskService;
        private readonly RootPanelParent _rootPanelParent;

        [Inject]
        public MainRunner(IObjectResolver container, GameTaskService gameTaskService,RootPanelParent rootPanelParent)
        {
            _container = container;
            _gameTaskService = gameTaskService;
            _rootPanelParent = rootPanelParent;
        }

        public void Start()
        {
            _rootPanelParent.loadingPanel.Hide(true).Forget();
            _gameTaskService.AddTaskToQueue<WaitBeforeRestartGameTask>(_container);
            _gameTaskService.AddTaskToQueue<RestartGameTask>(_container);
        }
    }
}