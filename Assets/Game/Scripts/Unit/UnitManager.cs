using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Pool;

namespace Game.Scripts.Unit
{
    [DisallowMultipleComponent]
    public abstract class UnitManager<T> : MonoBehaviour where T : UnitBase
    {
        [SerializeField] private AssetReference _unitReference;
        private T _prefab;
        private ObjectPool<T> _pool;
        private readonly List<T> _units = new();

        private ObjectPool<T> Pool
        {
            get
            {
                if (_pool == null)
                {
                    InitPool();
                }
                
                return _pool;
            }
            set => _pool = value;
        }

        public async UniTask LoadUnit()
        {
            var unitObject = await Addressables.InstantiateAsync(_unitReference);
            _prefab = unitObject.GetComponent<T>();
        }

        public void ReleaseUnit()
        {
            Addressables.ReleaseInstance(_prefab.gameObject);
        }

        private void InitPool(int initial = 10, int max = 100, bool collectionChecks = false)
        {
            Pool = new ObjectPool<T>(
                CreateSetup,
                GetSetup,
                ReleaseSetup,
                DestroySetup,
                collectionChecks,
                initial,
                max);
        }

        protected virtual T CreateSetup() => Instantiate(_prefab, transform);
        protected virtual void GetSetup(T unit) => unit.gameObject.SetActive(true);
        protected virtual void ReleaseSetup(T unit) => unit.gameObject.SetActive(false);
        protected virtual void DestroySetup(T unit) => Destroy(unit.gameObject);

        public T AddUnit()
        {
            T unit = Pool.Get();
            _units.Add(unit);
            return unit;
        }

        public void RemoveUnit(T unit)
        {
            int index = _units.IndexOf(unit);
            if (index == -1)
            {
                return;
            }

            int lastIndex = GetCount() - 1;
            _units[index] = _units[lastIndex];
            _units.RemoveAt(lastIndex);
            Pool.Release(unit);
        }

        public T AddSingle()
        {
            int unitCount = GetCount();
            if (unitCount != 0)
            {
                Debug.LogError($"{typeof(T)} is not single, unit count {unitCount}");
                ClearUnits();
            }

            return AddUnit();
        }

        public T GetSingle()
        {
            int unitCount = GetCount();
            if (unitCount != 1)
            {
                Debug.LogError($"{typeof(T)} is not single, unit count {unitCount}");
            }

            return _units[0];
        }

        public void ClearUnits()
        {
            int unitCount = GetCount();
            for (int i = unitCount - 1; i >= 0; i--)
            {
                RemoveUnit(_units[i]);
            }
        }

        public IReadOnlyCollection<T> GetUnits() => _units;
        public int GetCount() => _units.Count;
        public bool IsEmpty() => GetCount() == 0;
    }
}