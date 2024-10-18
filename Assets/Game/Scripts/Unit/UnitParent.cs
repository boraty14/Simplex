using UnityEngine;

namespace Game.Scripts.Unit
{
    public class UnitParent : MonoBehaviour
    {
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = transform;
        }
    }
}