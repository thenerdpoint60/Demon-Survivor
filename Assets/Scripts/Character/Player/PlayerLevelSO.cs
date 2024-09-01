using UnityEngine;

namespace VampireSurvivor
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
            currentXPCollected = 0;
            currentPlayerLevel = 1;
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
            Debug.Log("XP Rewarded To Player");
            if (HasPlayerLeveledUp())
            {
                currentPlayerLevel++;
                currentXPCollected = 0;
                EventManager.TriggerEvent(GameEvents.PlayerLevelUp, currentPlayerLevel);
                Debug.Log("PlayerLeveled Up");
                if (HasPlayerMaxedLevelUp())
                {
                    Debug.Log("PlayerLeveled Maxed");
                }
            }

            float currentLevelXP = (float)currentXPCollected / (xpForEachLevel * currentPlayerLevel);
            EventManager.TriggerEvent(GameEvents.XPCollected, currentLevelXP);
        }
    }
}