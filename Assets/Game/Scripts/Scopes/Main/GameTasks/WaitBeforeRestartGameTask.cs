using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Core.GameTask;

namespace Game.Scripts.Scopes.Main.GameTasks
{
    public class WaitBeforeRestartGameTask : GameTaskBase
    {
        private const float WaitDuration = 1f;

        public override async UniTask Run()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(WaitDuration));
        }
    }
}