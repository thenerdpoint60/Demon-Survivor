using UnityEngine;

namespace VampireSurvivor
{
    public class PlayerHealth : CharacterHealth
    {
        public override void Damage(int damage)
        {
            base.Damage(damage);
            EventManager.TriggerEvent(GameEvents.PlayerHealth, (float)GetCurrentHealth);
        }

        public override void Heal(int heal)
        {
            base.Damage(heal);
            EventManager.TriggerEvent(GameEvents.PlayerHealth, (float)GetCurrentHealth);
        }
    }
}