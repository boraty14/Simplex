using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Unit
{
    public class UnitHandler
    {
        private readonly Dictionary<Type, object> _unitManagers = new();

        public async UniTask LoadUnits<T>(string unitManagerReference) where T : UnitBase
        {
            var result = await Addressables.InstantiateAsync(unitManagerReference);
            var unitManager = result.GetComponent<UnitManager<T>>();
            Type unitType = typeof(T);
            _unitManagers.Add(unitType, unitManager);
        }

        public void ReleaseUnits<T>(UnitManager<T> unitManager) where T : UnitBase
        {
            Type unitType = typeof(T);
            _unitManagers.Remove(unitType);
            Addressables.ReleaseInstance(unitManager.gameObject);
        }

        public UnitManager<T> Get<T>() where T : UnitBase
        {
            Type unitType = typeof(T);
            return (UnitManager<T>)_unitManagers[unitType];
        }
    }
}