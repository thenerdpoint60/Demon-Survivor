using System;
using UnityEngine;

namespace VampireSurvivor
{
    public class PlayerLevel : MonoBehaviour, ICollectable
    {
        [SerializeField] private PlayerLevelSO playerLevelSO;

        public void Reward()
        {
            playerLevelSO.RewardXP(1);
        }
    }
}