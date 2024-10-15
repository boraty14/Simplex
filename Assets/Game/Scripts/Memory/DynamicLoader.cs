using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Memory
{
    public class DynamicLoader
    {
        private readonly List<GameObject> _loadedObjects = new();

        public async UniTask<T> LoadObject<T>(string reference, Transform parent)
        {
            var result = await Addressables.InstantiateAsync(reference, parent);
            _loadedObjects.Add(result);
            return result.GetComponent<T>();
        }

        public void ReleaseLoadedObjects()
        {
            foreach (var loadedObject in _loadedObjects)
            {
                Addressables.ReleaseInstance(loadedObject);
            }
        }
    }
}