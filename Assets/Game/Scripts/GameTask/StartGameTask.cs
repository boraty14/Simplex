using Cysharp.Threading.Tasks;
using Game.Scripts.Components;
using Game.Scripts.Sound;
using VContainer;

namespace Game.Scripts.GameTask
{
    public class StartGameTask : GameTaskBase
    {
        private readonly SoundService _soundService;
        private readonly RootLoadingScreen _rootLoadingScreen;

        [Inject]
        public StartGameTask(SoundService soundService, RootLoadingScreen rootLoadingScreen)
        {
            _soundService = soundService;
            _rootLoadingScreen = rootLoadingScreen;
        }
        
        public override UniTask Run()
        {
            _rootLoadingScreen.Toggle(false);
            return UniTask.CompletedTask;
        }
    }
}