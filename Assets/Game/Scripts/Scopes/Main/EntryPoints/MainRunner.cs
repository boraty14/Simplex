using Game.Scripts.Scopes.Main.GameTasks;
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

        [Inject]
        public MainRunner(IObjectResolver container, GameTaskService gameTaskService)
        {
            _container = container;
            _gameTaskService = gameTaskService;
        }

        public void Start()
        {
            _gameTaskService.AddTaskToQueue<TogglePanelsGameTask>(_container);
            _gameTaskService.AddTaskToQueue<RestartGameTask>(_container);
        }
    }
}