using UnityEngine;
using VContainer;

namespace Game.Scripts.Scopes.Root.Components
{
    public class PanelParent : MonoBehaviour
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private Canvas _canvas;
        [Inject] private RootUICamera _rootUICamera;
        public Transform SpawnTransform => _spawnTransform;

        private void Awake()
        {
            _canvas.worldCamera = _rootUICamera.Camera;
        }
    }
}