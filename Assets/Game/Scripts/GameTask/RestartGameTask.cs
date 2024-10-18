using Cysharp.Threading.Tasks;
using Game.Scripts.Components;
using UnityEngine.SceneManagement;
using VContainer;

namespace Game.Scripts.GameTask
{
    public class RestartGameTask : GameTaskBase
    {
        private readonly RootLoadingScreen _rootLoadingScreen;

        [Inject]
        public RestartGameTask(RootLoadingScreen rootLoadingScreen)
        {
            _rootLoadingScreen = rootLoadingScreen;
        }

        public override UniTask Run()
        {
            _rootLoadingScreen.Toggle(true);
            SceneManager.LoadScene(0);
            return UniTask.CompletedTask;
        }
    }
}