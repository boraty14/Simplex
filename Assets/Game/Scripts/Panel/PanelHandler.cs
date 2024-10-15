using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Panel
{
    public class PanelHandler
    {
        private readonly Dictionary<Type, PanelBase> _loadedPanels = new();


        public async UniTask LoadPanel<T>(string panelReference) where T : PanelBase
        {
            var panelKey = typeof(T);
            var panelObject = await Addressables.InstantiateAsync(panelReference);
            var loadedPanel = panelObject.GetComponent<T>();
            _loadedPanels.Add(panelKey,loadedPanel);
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

            await panel.Close(isImmediate);
            return (T)panel;
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