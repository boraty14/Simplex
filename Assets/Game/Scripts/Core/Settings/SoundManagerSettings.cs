using Game.Scripts.Core.SoundSystem;
using UnityEngine;

namespace Game.Scripts.Core.Settings
{
    [CreateAssetMenu(menuName = "Game/Settings/Sound Manager Settings", fileName = "SoundManagerSettings")]
    public class SoundManagerSettings : ScriptableObject
    {
        public SoundEmitter soundEmitterPrefab;
        public bool collectionCheck;
        public int defaultCapacity;
        public int maxPoolSize;
        public int maxSoundInstances;
    }
}