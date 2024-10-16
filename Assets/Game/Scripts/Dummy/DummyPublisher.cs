using System;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Dummy
{
    public class DummyPublisher : IStartable
    {
        private readonly IPublisher<DummyEvent> _dummyPublisher;
        private readonly IDisposable _disposable;

        [Inject]
        public DummyPublisher(IPublisher<DummyEvent> dummyPublisher)
        {
            _dummyPublisher = dummyPublisher;
        }
        
        public void Start()
        {
            Debug.Log("sss");
            _dummyPublisher.Publish(new DummyEvent
            {
                Id = 11
            });
        }
    }
}