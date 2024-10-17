using UnityEngine;

namespace Game.Scripts.Core.SoundSystem
{
    public class SoundParent : MonoBehaviour
    {
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = transform;
        }
    }
}