using Game.Scripts.Components;
using Game.Scripts.GameTask;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Main
{
    public class MainRunner : IStartable
    {
        private readonly GameTaskService _gameTaskService;
        private readonly RootLoadingScreen _rootLoadingPanel;

        [Inject]
        public MainRunner(GameTaskService gameTaskService, RootLoadingScreen rootLoadingScreen)
        {
            _gameTaskService = gameTaskService;
            _rootLoadingPanel = rootLoadingScreen;
        }

        public void Start()
        {
            _rootLoadingPanel.Toggle(true);
            _gameTaskService.AddTaskToQueue<StartGameTask>();
        }
    }
}