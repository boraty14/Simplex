using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer.Unity;

namespace Game.Scripts.Scopes.Root.Services
{
    public class ScopeLoadService
    {
        private readonly Dictionary<string, GameObject> _loadedScopes = new();

        public void LoadScope<T>() where T : LifetimeScope
        {
            var scopeKey = typeof(T).Name;
            Addressables.InstantiateAsync(scopeKey).Completed += scopeHandle =>
            {
                _loadedScopes.Add(scopeKey, scopeHandle.Result);
            };
        }

        public void UnloadScope<T>() where T : LifetimeScope
        {
            var scopeKey = typeof(T).Name;
            Addressables.ReleaseInstance(_loadedScopes[scopeKey]);
            _loadedScopes.Remove(scopeKey);
        }

        public void Reset()
        {
            foreach (var loadedScope  in _loadedScopes.Values)
            {
                Addressables.ReleaseInstance(loadedScope);
            }
            _loadedScopes.Clear();
        }
    }
}