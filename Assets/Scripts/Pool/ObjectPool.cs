using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivor
{
    public class ObjectPool
    {
        private readonly Queue<GameObject> poolQueue;
        private readonly GameObject prefab;
        private readonly Transform parentTransform;

        public ObjectPool(GameObject prefab, int initialSize, Transform parentTransform)
        {
            poolQueue = new Queue<GameObject>();
            this.prefab = prefab;
            this.parentTransform = parentTransform;

            for (int i = 0; i < initialSize; i++)
            {
                GameObject newObject = Object.Instantiate(this.prefab, this.parentTransform);
                newObject.SetActive(false);
                poolQueue.Enqueue(newObject);
            }
        }

        public GameObject GetFromPool()
        {
            GameObject pooledObject;

            if (poolQueue.Count > 0)
            {
                pooledObject = poolQueue.Dequeue();
            }
            else
            {
                pooledObject = Object.Instantiate(prefab, parentTransform);
            }

            pooledObject.SetActive(true);

            return pooledObject;
        }

        public void ReturnToPool(GameObject pooledObject)
        {
            pooledObject.SetActive(false);
            poolQueue.Enqueue(pooledObject);
        }
    }
}
