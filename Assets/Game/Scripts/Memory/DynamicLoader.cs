using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Memory
{
    public class DynamicLoader
    {
        private readonly List<GameObject> _loadedObjects = new();

        public async UniTask<T> LoadObject<T>(string reference)
        {
            var result = await Addressables.InstantiateAsync(reference);
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