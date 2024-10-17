using System;
using Cysharp.Threading.Tasks;

namespace Game.Scripts.Core.GameTask
{
    public abstract class GameTaskBase : IDisposable
    {
        public abstract UniTask Run();

        public virtual void Dispose()
        {
            
        }

    }
}