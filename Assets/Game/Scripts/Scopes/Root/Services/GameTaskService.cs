using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Scripts.Core;
using VContainer;

namespace Game.Scripts.Scopes.Root.Services
{
    public class GameTaskService : IDisposable
    {
        private readonly Queue<GameTaskBase> _gameTaskQueue = new();
        private bool _isRunning;
        public bool IsEnabled = true;
        
        public async UniTask RunTaskIndependent<T>(IObjectResolver container, Action onComplete = null)
            where T : GameTaskBase
        {
            var gameTask = container.Resolve<T>();
            using (gameTask)
            {
                await gameTask.Run();
                onComplete?.Invoke();
            }
        }

        public void AddTaskToQueue<T>(IObjectResolver container) where T : GameTaskBase
        {
            var gameTask = container.Resolve<T>();
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

        public void ClearTasks()
        {
            _gameTaskQueue.Clear();
        }

        public void Dispose()
        {
            ClearTasks();
        }
    }
}