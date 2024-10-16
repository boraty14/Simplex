using Cysharp.Threading.Tasks;
using Game.Scripts.GameTask;
using Game.Scripts.Memory;
using Game.Scripts.Scene;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Scopes.Root.GameTasks
{
    public class ResetGameTask : GameTaskBase
    {
        private readonly SceneLoader _sceneLoader;
        private readonly DynamicLoader _dynamicLoader;
        private readonly GameTaskRunner _gameTaskRunner;

        public ResetGameTask(SceneLoader sceneLoader, DynamicLoader dynamicLoader, GameTaskRunner gameTaskRunner)
        {
            _sceneLoader = sceneLoader;
            _dynamicLoader = dynamicLoader;
            _gameTaskRunner = gameTaskRunner;
        }

        public override UniTask Run()
        {
            _dynamicLoader.ReleaseLoadedObjects();
            _sceneLoader.Reset();
            _gameTaskRunner.Clear();
            SceneManager.LoadScene(0);
            return UniTask.CompletedTask;
        }
    }
}