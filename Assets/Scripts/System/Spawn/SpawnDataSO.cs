using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivor
{
    [CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObjects/SpawnData", order = 1)]
    public class SpawnDataSO : ScriptableObject
    {
        [SerializeField] private GamePoolType poolKey;
        [SerializeField] private List<float> spawnWavesTime = new();
        [SerializeField] private float spawnTime = 5f;
        [SerializeField] private int minimumLevel = 1;

        private int currentSpawnWave = 1;
        public GamePoolType PoolKey => poolKey;
        public float SpawnTime => spawnTime;
        public int MinimumLevel => minimumLevel;

        private void OnEnable()
        {
            spawnTime = spawnWavesTime[0];
        }

        public void NextSpawnWave()
        {
            spawnTime = spawnWavesTime[currentSpawnWave];
            currentSpawnWave++;

            if (currentSpawnWave >= spawnWavesTime.Count)
                currentSpawnWave = spawnWavesTime.Count;
        }
    }
}