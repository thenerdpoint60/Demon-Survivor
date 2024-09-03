using UnityEngine;

namespace DemonSurvivor
{
    [System.Serializable]
    public class PoolConfig
    {
        [SerializeField] private GamePoolType poolKey;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int initialSize;

        public int InitialSize => initialSize;
        public GameObject Prefab => prefab;
        public GamePoolType PoolKey => poolKey;
    }
}
