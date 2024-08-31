using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivor
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private CharacterHealthSO healthStats;

        private void OnEnable()
        {
            healthStats.ResetHealth();
        }

        public virtual void Heal(int health)
        {
            healthStats.Heal(health);
        }

        public virtual void Damage(int damage)
        {
            healthStats.Damage(damage);
        }

        public bool HasDied()
        {
            return healthStats.HasDied();
        }

        public int GetCurrentHealth => healthStats.CurrentHealth;
        public int GetMaxHealth => healthStats.MaxHealth;
    }
}