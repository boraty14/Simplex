using UnityEngine;

namespace Game.Scripts.Sound
{
    [CreateAssetMenu(menuName = "Game/Settings/Sound Service Settings", fileName = "SoundServiceSettings")]
    public class SoundManagerSettings : ScriptableObject
    {
        public SoundEmitter soundEmitterPrefab;
        public bool collectionCheck;
        public int defaultCapacity;
        public int maxPoolSize;
        public int maxSoundInstances;
    }
}