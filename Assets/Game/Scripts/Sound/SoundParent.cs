using UnityEngine;

namespace Game.Scripts.Sound
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