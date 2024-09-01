using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivor
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private CharacterHealthSO healthStats;
        [SerializeField] private int currentHealth;

        private void OnEnable()
        {
            currentHealth = healthStats.MaxHealth;
        }

        public virtual void Heal(int health)
        {
            currentHealth += health;
            if (currentHealth > healthStats.MaxHealth)
                currentHealth = healthStats.MaxHealth;
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

        public int GetCurrentHealth => currentHealth;
        public int GetMaxHealth => healthStats.MaxHealth;
    }
}