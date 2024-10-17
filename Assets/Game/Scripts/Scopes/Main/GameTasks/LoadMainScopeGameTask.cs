using Cysharp.Threading.Tasks;
using Game.Scripts.Core.GameTask;

namespace Game.Scripts.Scopes.Main.GameTasks
{
    public class LoadMainScopeGameTask : GameTaskBase
    {
        public override UniTask Run()
        {
            return UniTask.CompletedTask;
        }
    }
}