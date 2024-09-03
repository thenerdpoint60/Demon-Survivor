using System;
using UnityEngine;

namespace DemonSurvivor
{
    [CreateAssetMenu(fileName = "PlayerLevel", menuName = "ScriptableObjects/PlayerLevel", order = 1)]
    public class PlayerLevelSO : ScriptableObject
    {
        [SerializeField] private int currentXPCollected = 0;
        [SerializeField] private int currentPlayerLevel = 1;
        [SerializeField] private int xpForEachLevel = 100;
        [SerializeField] private int maxPlayerLevel = 10;

        private int NextLevelXPNeeded => xpForEachLevel * currentPlayerLevel;

        public int CurrentXPCollected => currentXPCollected;
        public int CurrentPlayerLevel => currentPlayerLevel;
        public int XPForEachLevel => xpForEachLevel;
        public int MaxPlayerLevel => maxPlayerLevel;

        private void OnEnable()
        {
            ResetPlayer();
        }

        public void ResetPlayer()
        {
            currentXPCollected = 0;
            currentPlayerLevel = 1;
            UpdateCurrentXPPercentage();
        }

        private bool HasPlayerMaxedLevelUp()
        {
            return currentPlayerLevel >= maxPlayerLevel;
        }

        private bool HasPlayerLeveledUp()
        {
            return currentXPCollected >= NextLevelXPNeeded;
        }

        public void RewardXP(int amount)
        {
            if (HasPlayerMaxedLevelUp())
                return;

            currentXPCollected += amount;
            if (HasPlayerLeveledUp())
            {
                currentXPCollected = 0;
                currentPlayerLevel++;
                EventManager.TriggerEvent(GameEvents.PlayerLevelUp, currentPlayerLevel);
            }

            UpdateCurrentXPPercentage();
        }

        private void UpdateCurrentXPPercentage()
        {
            float currentCollectedXpPercentage = (float)currentXPCollected / NextLevelXPNeeded;
            EventManager.TriggerEvent(GameEvents.XPCollected, currentCollectedXpPercentage);
        }
    }
}