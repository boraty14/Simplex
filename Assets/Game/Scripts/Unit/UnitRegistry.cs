using System;
using System.Collections.Generic;

namespace Game.Scripts.Unit
{
    public class UnitRegistry
    {
        private readonly Dictionary<Type, object> _unitManagers = new();

        public void RegisterUnitManager<T>(UnitManager<T> unitManager) where T : UnitBase
        {
            var unitType = typeof(T);
            _unitManagers.Add(unitType,unitManager);
        }
        
        public void UnregisterUnitManager<T>() where T : UnitBase
        {
            var unitType = typeof(T);
            _unitManagers.Remove(unitType);
        }

        public UnitManager<T> Get<T>() where T : UnitBase
        {
            Type unitType = typeof(T);
            return (UnitManager<T>)_unitManagers[unitType];
        }
    }
}