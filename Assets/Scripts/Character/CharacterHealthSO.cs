using UnityEngine;

namespace VampireSurvivor
{
    [CreateAssetMenu(fileName = "CharacterHealth", menuName = "ScriptableObjects/CharacterHealth", order = 1)]
    public class CharacterHealthSO : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;
        [SerializeField] private int upgradeMaxHealthBy = 0;

        public int MaxHealth => maxHealth;
        public int CurrentHealth => currentHealth;
        public float UpgradeMaxHealthBy => upgradeMaxHealthBy;

        public void UpgradeMaxHealth()
        {
            maxHealth += upgradeMaxHealthBy;
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }

        public void Damage(int amount)
        {
            currentHealth -= amount;
            if (currentHealth < 0)
                currentHealth = 0;
        }

        public bool HasDied()
        {
            return CurrentHealth <= 0;
        }

        public void ResetHealth()
        {
            currentHealth = maxHealth;
        }
    }
}