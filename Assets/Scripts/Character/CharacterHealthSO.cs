using System;
using UnityEngine;

namespace VampireSurvivor
{
    [CreateAssetMenu(fileName = "CharacterHealth", menuName = "ScriptableObjects/CharacterHealth", order = 1)]
    public class CharacterHealthSO : ScriptableObject
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int upgradeMaxHealthBy = 20;

        private int initialMaxHealth;

        private void OnEnable()
        {
            initialMaxHealth = maxHealth;
        }

        public int MaxHealth => maxHealth;
        public float UpgradeMaxHealthByValue => upgradeMaxHealthBy;

        public void UpgradeMaxHealth()
        {
            maxHealth += upgradeMaxHealthBy;
        }

        private void OnDisable()
        {
            maxHealth = initialMaxHealth;
        }
    }
}