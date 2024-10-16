using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Scripts.Scopes.Root.Components;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;

namespace Game.Scripts.Panel
{
    public class PanelManager
    {
        private readonly Dictionary<Type, PanelBase> _loadedPanels = new();
        private readonly PanelParent _panelParent;

        [Inject]
        public PanelManager(PanelParent panelParent)
        {
            _panelParent = panelParent;
        }

        public async UniTask LoadPanel<T>() where T : PanelBase
        {
            var panelKey = typeof(T);
            var panelObject = await Addressables.InstantiateAsync(typeof(T).Name,_panelParent.SpawnTransform);
            var loadedPanel = panelObject.GetComponent<T>();
            _loadedPanels.Add(panelKey,loadedPanel);
        }
        
        public void UnloadPanel<T>() where T : PanelBase
        {
            var panelKey = typeof(T);
            if (!_loadedPanels.TryGetValue(panelKey, out var panel))
            {
                Debug.LogError($"Panel {panelKey} is not found");
                return;
            }

            Addressables.ReleaseInstance(panel.gameObject);
            _loadedPanels.Remove(panelKey);
        }
        
        public async UniTask<T> ShowPanel<T>(bool isImmediate = false) where T : PanelBase
        {
            var panelKey = typeof(T);
            if (!_loadedPanels.TryGetValue(panelKey, out var panel))
            {
                Debug.LogError($"Panel {panelKey} is not found");
                return null;
                
            }

            await panel.Show(isImmediate);
            return (T)panel;
        }

        public async UniTask<T> HidePanel<T>(bool isImmediate = false) where T : PanelBase
        {
            var panelKey = typeof(T);
            if (!_loadedPanels.TryGetValue(panelKey, out var panel))
            {
                Debug.LogError($"Panel {panelKey} is not found");
                return null;
            }

            await panel.Hide(isImmediate);
            return (T)panel;
        }

        public T GetPanel<T>() where T : PanelBase
        {
            var panelKey = typeof(T);
            if (_loadedPanels.TryGetValue(panelKey, out var panel))
            {
                return (T)panel;
            }

            Debug.LogError($"Panel {panelKey} is not found");
            return null;
        }
    }
}