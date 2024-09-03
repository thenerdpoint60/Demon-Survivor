using System.Collections.Generic;
using UnityEngine;

namespace DemonSurvivor
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance { get; private set; }

        private Dictionary<GamePoolType, ObjectPool> pools = new();

        [SerializeField] private List<PoolConfig> poolConfigs;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                InitializePools();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializePools()
        {
            foreach (var config in poolConfigs)
            {
                CreatePool(config.Prefab, config.InitialSize, config.PoolKey);
            }
        }

        public void CreatePool(GameObject prefab, int initialSize, GamePoolType key)
        {
            GameObject parentObject = new GameObject($"{key} Pool");
            parentObject.transform.SetParent(transform);
            var pool = new ObjectPool(prefab, initialSize, parentObject.transform);
            pools[key] = pool;
        }

        public GameObject GetFromPool(GamePoolType key, bool isSpawnState = true)
        {
            if (pools.TryGetValue(key, out var pool))
            {
                return pool.GetFromPool(isSpawnState);
            }

            Debug.LogError($"Pool with key {key} does not exist.");
            return null;
        }

        public void ReturnToPool(GamePoolType key, GameObject objectToReturn)
        {
            if (pools.TryGetValue(key, out var pool))
            {
                pool.ReturnToPool(objectToReturn);
            }
            else
            {
                Debug.LogError($"Pool with key {key} does not exist.");
            }
        }
    }
}
