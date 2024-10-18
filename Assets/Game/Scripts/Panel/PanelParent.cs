using Game.Scripts.Components;
using UnityEngine;
using VContainer;

namespace Game.Scripts.Panel
{
    public class PanelParent : MonoBehaviour
    {
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private Canvas _canvas;
        [Inject] private GameUICamera _gameUICamera;
        public Transform SpawnTransform => _spawnTransform;

        private void Awake()
        {
            _canvas.worldCamera = _gameUICamera.Camera;
        }
    }
}