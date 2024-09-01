using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivor
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<SpawnDataSO> spawnDatas;
        [SerializeField] private List<Transform> spawnPositions;

        private bool isSpawning = true;

        private void Start()
        {
            StartSpawning(1);
        }

        private void StartSpawning(int level)
        {
            for (int i = 0, spawnDataListCount = spawnDatas.Count; i < spawnDataListCount; i++)
            {
                SpawnDataSO spawnData = spawnDatas[i];
                if (spawnData.MinimumLevel >= level)
                    StartCoroutine(SpawnCoroutine(spawnData));
            }
        }

        private void StopSpawning()
        {
            for (int i = 0, spawnDataListCount = spawnDatas.Count; i < spawnDataListCount; i++)
            {
                StopCoroutine(SpawnCoroutine(spawnDatas[i]));
            }
        }

        private void UpgradeSpawnData()
        {
            for (int i = 0, spawnDataListCount = spawnDatas.Count; i < spawnDataListCount; i++)
            {
                spawnDatas[i].NextSpawnWave();
            }
        }

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
        }

        private void OnDisable()
        {
            EventManager.StartListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
        }

        private void OnPlayerLevelUp(object playerLevel)
        {
            int currentPlayerLevel = (int)playerLevel;
            if (currentPlayerLevel % 3 == 0)
            {
                isSpawning = false;
                StopSpawning();
                UpgradeSpawnData();
                StartSpawning(currentPlayerLevel);
            }
            isSpawning = true;
        }

        private IEnumerator SpawnCoroutine(SpawnDataSO spawnData)
        {
            WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(spawnData.SpawnTime);
            while (isSpawning)
            {
                yield return waitForSecondsRealtime;
                Spawn(spawnData);
            }
        }

        private void Spawn(SpawnDataSO spawnData)
        {
            Transform spawnPosition = GetRandomSpawnPosition();
            GameObject spawnedGameObject = PoolManager.Instance.GetFromPool(spawnData.PoolKey, false);

            if (spawnedGameObject != null)
            {
                Vector3 spawnPos = spawnPosition.position;
                spawnPos.z = 0;
                spawnedGameObject.transform.position = spawnPos;
                spawnedGameObject.SetActive(true);
                Debug.Log($"Spawned Object at {spawnedGameObject.transform.position}");
            }
            else
            {
                Debug.LogError($"No prefab found for spawn type: {spawnData.PoolKey}");
            }
        }

        private Transform GetRandomSpawnPosition()
        {
            int randomIndex = Random.Range(0, spawnPositions.Count);
            return spawnPositions[randomIndex];
        }
    }
}