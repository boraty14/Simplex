using System;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Dummy
{
    public class DummySubscriber : IPostInitializable, IDisposable
    {
        private readonly ISubscriber<DummyEvent> _dummySubscriber;
        private readonly IDisposable _disposable;

        [Inject]
        public DummySubscriber(ISubscriber<DummyEvent> dummySubscriber)
        {
            var disposableBagBuilder = DisposableBag.CreateBuilder();
            _dummySubscriber = dummySubscriber;
            _dummySubscriber.Subscribe(dummyEvent => Debug.Log(dummyEvent.Id)).AddTo(disposableBagBuilder);
            _disposable = disposableBagBuilder.Build();
        }
        
        public void PostInitialize()
        {
            
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}