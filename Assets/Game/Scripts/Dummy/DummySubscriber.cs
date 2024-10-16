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
            _dummySubscriber = dummySubscriber;
        }
        
        public void PostInitialize()
        {
            var disposableBagBuilder = DisposableBag.CreateBuilder();
            _dummySubscriber.Subscribe(dummyEvent => Debug.Log(dummyEvent.Id)).AddTo(disposableBagBuilder);
            disposableBagBuilder.Build();
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}