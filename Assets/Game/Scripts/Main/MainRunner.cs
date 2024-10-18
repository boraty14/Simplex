using Game.Scripts.GameTask;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Main
{
    public class MainRunner : IStartable
    {
        private readonly GameTaskService _gameTaskService;

        [Inject]
        public MainRunner(GameTaskService gameTaskService)
        {
            _gameTaskService = gameTaskService;
        }

        public void Start()
        {
            _gameTaskService.AddTaskToQueue<StartGameTask>();
        }
    }
}