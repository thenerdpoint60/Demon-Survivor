using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace VampireSurvivor
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<SpawnDataSO> spawnDatas;
        [SerializeField] private List<Transform> spawnPositions;

        private bool isSpawning = true;
        private bool isGamePause = false;

        private void Start()
        {
            StartSpawning(1);
        }

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
            EventManager.StartListening(GameEvents.GamePause, OnGamePause);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
            EventManager.StopListening(GameEvents.GamePause, OnGamePause);
        }

        private void StartSpawning(int level)
        {
            for (int i = 0, spawnDataListCount = spawnDatas.Count; i < spawnDataListCount; i++)
            {
                SpawnDataSO spawnData = spawnDatas[i];
                if (spawnData.MinimumLevel <= level)
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

        private void OnGamePause(object obj)
        {
            isGamePause = (bool)obj;
        }

        private void OnPlayerLevelUp(object playerLevel)
        {
            int currentPlayerLevel = (int)playerLevel;
            Debug.Log($"Player Level {currentPlayerLevel}");
            isSpawning = false;
            StopSpawning();
            if (currentPlayerLevel == 4 || currentPlayerLevel == 7)
                UpgradeSpawnData();
            isSpawning = true;
            StartSpawning(currentPlayerLevel);
        }

        private IEnumerator SpawnCoroutine(SpawnDataSO spawnData)
        {
            WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(spawnData.SpawnTime);
            while (isSpawning)
            {
                if (!isGamePause)
                    Spawn(spawnData);
                yield return waitForSecondsRealtime;
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