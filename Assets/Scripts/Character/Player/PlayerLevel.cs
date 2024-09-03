using System;
using UnityEngine;

namespace DemonSurvivor
{
    public class PlayerLevel : MonoBehaviour, ICollectable
    {
        [SerializeField] private PlayerLevelSO playerLevelSO;

        private void OnEnable()
        {
            playerLevelSO.ResetPlayer();
        }

        public void Collect(int value)
        {
            playerLevelSO.RewardXP(value);
        }
    }
}