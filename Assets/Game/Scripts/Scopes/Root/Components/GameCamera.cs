using UnityEngine;

namespace Game.Scripts.Scopes.Root.Components
{
    public class GameCamera : MonoBehaviour
    {
        public Camera Camera { get; private set; }

        private void Awake()
        {
            Camera = GetComponent<Camera>();
        }
    }
}