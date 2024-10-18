using System;
using System.Collections.Generic;
using UnityEngine.Pool;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Game.Scripts.Sound
{
    public class SoundService : IPostInitializable, IDisposable
    {
        private readonly IObjectResolver _container;
        private readonly SoundManagerSettings _soundManagerSettings;
        private readonly SoundParent _soundParent;
        private readonly List<SoundEmitter> _activeSoundEmitters = new();
        public readonly Dictionary<SoundData, int> Counts = new();
        private IObjectPool<SoundEmitter> _soundEmitterPool;

        public SoundService(IObjectResolver container, SoundManagerSettings soundManagerSettings,
            SoundParent soundParent)
        {
            _container = container;
            _soundManagerSettings = soundManagerSettings;
            _soundParent = soundParent;
        }

        public void PostInitialize()
        {
            InitPool();
        }

        public SoundBuilder CreateSound() => _container.Resolve<SoundBuilder>();

        public bool CanPlaySound(SoundData soundData)
        {
            if (!Counts.TryGetValue(soundData, out var count))
            {
                return true;
            }

            return count < _soundManagerSettings.maxSoundInstances;
        }

        public SoundEmitter Get() => _soundEmitterPool.Get();

        public void ReturnToPool(SoundEmitter soundEmitter) => _soundEmitterPool.Release(soundEmitter);

        private void InitPool()
        {
            _soundEmitterPool = new ObjectPool<SoundEmitter>(
                CreateSoundEmitter,
                OnTakeFromPool,
                OnReturnedToPool,
                OnDestroyPoolObject,
                _soundManagerSettings.collectionCheck,
                _soundManagerSettings.defaultCapacity,
                _soundManagerSettings.maxPoolSize
            );
        }

        private SoundEmitter CreateSoundEmitter()
        {
            var soundEmitter = _container.Instantiate(_soundManagerSettings.soundEmitterPrefab, _soundParent.Transform);
            soundEmitter.gameObject.SetActive(false);
            return soundEmitter;
        }

        private void OnTakeFromPool(SoundEmitter soundEmitter)
        {
            soundEmitter.gameObject.SetActive(true);
            _activeSoundEmitters.Add(soundEmitter);
        }

        private void OnReturnedToPool(SoundEmitter soundEmitter)
        {
            if (Counts.TryGetValue(soundEmitter.SoundData, out var count))
            {
                Counts[soundEmitter.SoundData] = count - 1;
            }
            soundEmitter.gameObject.SetActive(false);
            _activeSoundEmitters.Remove(soundEmitter);
        }

        private void OnDestroyPoolObject(SoundEmitter soundEmitter)
        {
            Object.Destroy(soundEmitter.gameObject);
        }

        public void Dispose()
        {
        }
    }
}