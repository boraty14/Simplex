using System;
using Cysharp.Threading.Tasks;
using Dummy;
using Game.Scripts.Panel;
using Game.Scripts.Unit;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Gameplay
{
    public class GameRunner : IStartable
    {
        private readonly GameStateData _gameStateData;
        private readonly UnitManager<DummyUnit> _dummyUnitManager;
        private readonly PanelManager _panelManager;

        [Inject]
        public GameRunner(GameStateData gameStateData, UnitManager<DummyUnit> dummyUnitManager,
            PanelManager panelManager)
        {
            _gameStateData = gameStateData;
            _dummyUnitManager = dummyUnitManager;
            _panelManager = panelManager;
        }

        private async UniTaskVoid LoadAndAddUnit()
        {
            await _dummyUnitManager.LoadUnit();
            _dummyUnitManager.AddUnit();
            await _panelManager.LoadPanel<DummyPanel>();
            await _panelManager.ShowPanel<DummyPanel>();
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            await _panelManager.HidePanel<DummyPanel>();

        }

        public void Start()
        {
            Debug.Log(_gameStateData.Id);
            LoadAndAddUnit().Forget();
        }
    }
}