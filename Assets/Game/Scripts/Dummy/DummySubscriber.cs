using System;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Dummy
{
    public class DummySubscriber : IPostInitializable
    {
        private readonly ISubscriber<DummyEvent> _dummySubscriber;
        private readonly IDisposable _disposable;

        [Inject]
        public DummySubscriber(ISubscriber<DummyEvent> dummySubscriber, ISubscriber<int> dummy)
        {
            var disposableBagBuilder = DisposableBag.CreateBuilder();
            //_dummySubscriber = dummySubscriber;
            dummySubscriber.Subscribe(dummyEvent => Debug.Log(dummyEvent.Id));
            dummy.Subscribe(dummyEvent => Debug.Log(dummyEvent));
            
        }
        
        public void PostInitialize()
        {
            
        }
        
        // public void Dispose()
        // {
        //     _disposable?.Dispose();
        // }
    }
}