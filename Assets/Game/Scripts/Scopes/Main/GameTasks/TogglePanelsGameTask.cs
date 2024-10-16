using System;
using Cysharp.Threading.Tasks;
using Game.Scripts.Core;
using Game.Scripts.Panel;
using VContainer;

namespace Game.Scripts.Scopes.Main.GameTasks
{
    public class TogglePanelsGameTask : GameTaskBase
    {
        private readonly PanelManager _panelManager;

        [Inject]
        public TogglePanelsGameTask(PanelManager panelManager)
        {
            _panelManager = panelManager;
        }
        
        public override async UniTask Run()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        }
    }
}