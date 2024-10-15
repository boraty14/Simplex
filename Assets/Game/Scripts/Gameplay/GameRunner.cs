using Game.Scripts.GameTask;
using Game.Scripts.Memory;
using Game.Scripts.Panel;
using Game.Scripts.Scene;
using Game.Scripts.Unit;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameStateData _gameStateData;
        
        private GameTaskRunner _gameTaskRunner;
        private SceneLoader _sceneLoader;
        private UnitRegistry _unitRegistry;
        private PanelHandler _panelHandler;
        private DynamicLoader _dynamicLoader;

        private void Awake()
        {
            _gameTaskRunner = new GameTaskRunner();
            _sceneLoader = new SceneLoader();
            _unitRegistry = new UnitRegistry();
            _panelHandler = new PanelHandler();
            _dynamicLoader = new DynamicLoader();
            _gameStateData = new GameStateData();
        }
    }
}