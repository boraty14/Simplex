using System;
using Cysharp.Threading.Tasks;
using Dummy;
using Game.Scripts.GameTask;
using Game.Scripts.Panel;
using Game.Scripts.Unit;
using VContainer;

namespace Game.Scripts.Scopes.Main.GameTasks
{
    public class TogglePanelsGameTask : GameTaskBase
    {
        private readonly UnitManager<DummyUnit> _dummyUnitManager;
        private readonly PanelManager _panelManager;

        [Inject]
        public TogglePanelsGameTask(UnitManager<DummyUnit> dummyUnitManager, PanelManager panelManager)
        {
            _dummyUnitManager = dummyUnitManager;
            _panelManager = panelManager;
        }
        
        public override async UniTask Run()
        {
            await _dummyUnitManager.LoadUnit();
            _dummyUnitManager.AddUnit();
            await _panelManager.LoadPanel<DummyPanel>();
            await _panelManager.ShowPanel<DummyPanel>();
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            await _panelManager.HidePanel<DummyPanel>();
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        }
    }
}