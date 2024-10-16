using System;
using Cysharp.Threading.Tasks;
using Dummy;
using Game.Scripts.GameTask;
using Game.Scripts.Panel;
using Game.Scripts.Scopes.Root.GameTasks;
using Game.Scripts.Unit;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Main.EntryPoints
{
    public class MainRunner : IStartable
    {
        private readonly IObjectResolver _container;
        private readonly UnitManager<DummyUnit> _dummyUnitManager;
        private readonly PanelManager _panelManager;
        private readonly GameTaskRunner _gameTaskRunner;

        [Inject]
        public MainRunner(IObjectResolver container, UnitManager<DummyUnit> dummyUnitManager, PanelManager panelManager, GameTaskRunner gameTaskRunner)
        {
            _container = container;
            _dummyUnitManager = dummyUnitManager;
            _panelManager = panelManager;
            _gameTaskRunner = gameTaskRunner;
        }

        private async UniTaskVoid LoadAndAddUnit()
        {
            await _dummyUnitManager.LoadUnit();
            _dummyUnitManager.AddUnit();
            await _panelManager.LoadPanel<DummyPanel>();
            await _panelManager.ShowPanel<DummyPanel>();
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            await _panelManager.HidePanel<DummyPanel>();
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            _gameTaskRunner.AddTaskToQueue(_container.Resolve<ResetGameTask>());
        }

        public void Start()
        {
            LoadAndAddUnit().Forget();
        }
    }
}