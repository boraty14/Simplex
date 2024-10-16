using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Panel;
using Game.Scripts.Unit;
using VContainer;
using VContainer.Unity;

namespace Dummy
{
    public class DummyRunner : IStartable
    {
        private readonly UnitManager<DUnit> _dUnitManager;
        private readonly PanelManager _panelManager;
        
        [Inject]
        public DummyRunner(UnitManager<DUnit> dUnitManager, PanelManager panelManager)
        {
            _dUnitManager = dUnitManager;
            _panelManager = panelManager;
        }

        private async UniTaskVoid LoadAndAddUnit()
        {
            await _dUnitManager.LoadUnit();
            _dUnitManager.AddUnit();
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            _panelManager.ShowPanel<DummyPanel>().Forget();

        }

        public void Start()
        {
            LoadAndAddUnit().Forget();
        }
    }
}