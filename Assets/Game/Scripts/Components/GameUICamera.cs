using UnityEngine;

namespace Game.Scripts.Components
{
    public class GameUICamera : MonoBehaviour
    {
        public Camera Camera { get; private set; }

        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }
    }
}