using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.GameTask;
using VContainer;

namespace Game.Scripts.Scopes.Root.Services
{
    public class GameTaskService
    {
        private readonly GameTaskRunner _gameTaskRunner;
        
        [Inject]
        public GameTaskService(GameTaskRunner gameTaskRunner)
        {
            _gameTaskRunner = gameTaskRunner;
        }

        public void AddTaskToQueue<T>(IObjectResolver container) where T : GameTaskBase
        {
            var gameTask = container.Resolve<T>();
            _gameTaskRunner.AddTaskToQueue(gameTask);
        }

        public async UniTask RunTaskIndependent<T>(IObjectResolver container, Action onComplete = null) where T : GameTaskBase
        {
            var gameTask = container.Resolve<T>();
            await _gameTaskRunner.RunTaskIndependent(gameTask, onComplete);
        }
    }
}