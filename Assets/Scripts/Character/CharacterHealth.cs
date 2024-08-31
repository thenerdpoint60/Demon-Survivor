using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivor
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;

        private void OnEnable()
        {
            currentHealth = maxHealth;
        }

        public virtual void Heal(int health)
        {
            currentHealth += health;
            if (currentHealth > maxHealth)
                currentHealth = maxHealth;
        }

        public virtual void Damage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth < 0)
                currentHealth = 0;
        }

        public bool HasDied()
        {
            return currentHealth <= 0;
        }

        public void UpgradeMaxHealth(int newMaxHealth)
        {
            maxHealth = newMaxHealth;
        }

        public int GetCurrentHealth => currentHealth;
        public int GetMaxHealth => maxHealth;
    }
}