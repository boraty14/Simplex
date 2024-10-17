using UnityEngine;

namespace Game.Scripts.Core.Unit
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