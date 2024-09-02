using UnityEngine;

namespace VampireSurvivor
{
    public class PlayerHealth : CharacterHealth
    {
        [SerializeField] private ParticleSystem damageBloodParticle;

        public override void Damage(int damage)
        {
            base.Damage(damage);
            EventManager.TriggerEvent(GameEvents.PlayerHealth, (float)GetCurrentHealth);
            damageBloodParticle.Play();
            if (HasDied())
                EventManager.TriggerEvent(GameEvents.PlayerDie);
        }

        public override void Heal(int heal)
        {
            base.Heal(heal);
            EventManager.TriggerEvent(GameEvents.PlayerHealth, (float)GetCurrentHealth);
        }
    }
}