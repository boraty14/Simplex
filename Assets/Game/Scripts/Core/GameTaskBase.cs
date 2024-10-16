using System;
using Cysharp.Threading.Tasks;

namespace Game.Scripts.Core
{
    public abstract class GameTaskBase : IDisposable
    {
        public abstract UniTask Run();

        public virtual void Dispose()
        {
            
        }

    }
}