using UnityEngine;

namespace Game.Scripts.Components
{
    public class RootLoadingScreen : MonoBehaviour
    {
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        public void Toggle(bool state)
        {
            _canvas.enabled = state;
        }
    }
}