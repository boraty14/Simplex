using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game.Scripts.GameTask
{
    public class GameTaskRunner : IDisposable
    {
        private readonly Queue<GameTaskBase> _gameTaskQueue = new();
        private bool _isRunning;
        public bool IsEnabled = true;

        public async UniTask RunTaskIndependent(GameTaskBase gameTask, Action onComplete = null)
        {
            using (gameTask)
            {
                await gameTask.Run();
                onComplete?.Invoke();
            }
        }

        public void AddTaskToQueue(GameTaskBase gameTask)
        {
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