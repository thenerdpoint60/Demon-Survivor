using System;
using UnityEngine;

namespace VampireSurvivor
{
    public class PlayerLevel : MonoBehaviour, ICollectable
    {
        [SerializeField] private PlayerLevelSO playerLevelSO;

        public void Collect(int value)
        {
            playerLevelSO.RewardXP(value);
        }
    }
}