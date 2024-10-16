using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.GameTask
{
    public class GameTaskRunner
    {
        private readonly Queue<GameTaskBase> _gameTaskQueue = new();
        private bool _isRunning;

        public void Clear()
        {
            _gameTaskQueue.Clear();
        }

        public static async UniTask RunTaskIndependent(GameTaskBase gameTask, Action onFinal = null)
        {
            using (gameTask)
            {
                await ExecuteGameTask(gameTask);
                onFinal?.Invoke();
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
                using var gameTask = _gameTaskQueue.Dequeue();
                await ExecuteGameTask(gameTask);
            }

            _isRunning = false;
        }

        private static async UniTask ExecuteGameTask(GameTaskBase gameTask)
        {
            try
            {
                await gameTask.Run();
            }
            catch (Exception runException)
            {
                Debug.LogException(runException);
                HandleTaskError(gameTask);
            }
        }

        private static void HandleTaskError(GameTaskBase gameTask)
        {
            try
            {
                gameTask.HandleError();
            }
            catch (Exception handleErrorException)
            {
                Debug.LogException(handleErrorException);
            }
        }
    }
}