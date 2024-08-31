using UnityEngine;

namespace VampireSurvivor
{
    [System.Serializable]
    public class PoolConfig
    {
        public GamePoolType poolKey;
        public GameObject prefab;
        public int initialSize;
    }
}
