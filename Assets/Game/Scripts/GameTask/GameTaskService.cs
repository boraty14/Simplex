using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using VContainer;

namespace Game.Scripts.GameTask
{
    public class GameTaskService : IDisposable
    {
        private readonly IObjectResolver _container;
        private readonly Queue<GameTaskBase> _gameTaskQueue = new();
        private bool _isRunning;
        public bool IsEnabled = true;

        [Inject]
        public GameTaskService(IObjectResolver container)
        {
            _container = container;
        }

        public async UniTask RunTaskIndependent<T>() where T : GameTaskBase
        {
            var gameTask = _container.Resolve<T>();
            using (gameTask)
            {
                await gameTask.Run();
            }
        }

        public void AddTaskToQueue<T>() where T : GameTaskBase
        {
            var gameTask = _container.Resolve<T>();
            _gameTaskQueue.Enqueue(gameTask);
            if (!_isRunning)
            {
                StartGameTaskRunner().Forget();
            }
        }

        private async UniTaskVoid StartGameTaskRunner()
        {
            _isRunning = true;

            while (_gameTaskQueue.Count > 0)
            {
                while (!IsEnabled)
                {
                    await UniTask.Yield();
                }

                using var gameTask = _gameTaskQueue.Dequeue();
                await gameTask.Run();
            }

            _isRunning = false;
        }

        public void Dispose()
        {
            _gameTaskQueue.Clear();
        }
    }
}