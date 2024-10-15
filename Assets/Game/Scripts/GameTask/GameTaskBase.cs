using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace Game.Scripts.GameTask
{
    public abstract class GameTaskBase : IDisposable
    {
        protected abstract UniTask RunInternally();
        protected readonly CancellationToken Ct;

        protected GameTaskBase(CancellationToken ct)
        {
            Ct = ct;
        }

        public async UniTask Run()
        {
            if (Ct.IsCancellationRequested)
            {
                return;
            }

            await RunInternally();
        }

        public virtual void HandleError()
        {
            
        }

        public virtual void Dispose()
        {
            
        }

    }
}