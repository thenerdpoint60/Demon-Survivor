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

        public int CurrentXPCollected => currentXPCollected;
        public int CurrentPlayerLevel => currentPlayerLevel;
        public int XPForEachLevel => xpForEachLevel;
        public int MaxPlayerLevel => maxPlayerLevel;

        public bool HasPlayerMaxedLevelUp()
        {
            return currentPlayerLevel >= maxPlayerLevel;
        }

        public bool HasPlayerLeveledUp()
        {
            return currentXPCollected >= xpForEachLevel * currentPlayerLevel;
        }

        public void RewardXP(int amount)
        {
            if (HasPlayerMaxedLevelUp())
                return;

            currentXPCollected += amount;
            float currentLevelXP = (float)currentXPCollected / (xpForEachLevel * currentPlayerLevel);
            EventManager.TriggerEvent(GameEvents.XPCollected, currentLevelXP);
            Debug.Log("XP Rewarded To Player");
            if (HasPlayerLeveledUp())
            {
                currentPlayerLevel++;
                EventManager.TriggerEvent(GameEvents.PlayerLevelUp, currentPlayerLevel);
                Debug.Log("PlayerLeveled Up");
                if (HasPlayerMaxedLevelUp())
                {
                    Debug.Log("PlayerLeveled Maxed");
                }
            }
        }
    }
}