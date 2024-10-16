using System;
using Cysharp.Threading.Tasks;

namespace Game.Scripts.GameTask
{
    public abstract class GameTaskBase : IDisposable
    {
        public abstract UniTask Run();

        public virtual void HandleError()
        {
            
        }

        public virtual void Dispose()
        {
            
        }

    }
}