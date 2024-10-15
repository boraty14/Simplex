using UnityEngine;

namespace Game.Scripts.Scopes.Root.Components
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