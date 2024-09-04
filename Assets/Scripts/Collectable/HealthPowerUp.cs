using DG.Tweening;
using System;
using UnityEngine;

namespace DemonSurvivor
{
    public class HealthPowerUp : CollectableItem
    {
        [SerializeField] private int healthHeal = 10;

        public void Heal(Collider2D Collider2D)
        {
            IHealth healAble = Collider2D.gameObject.GetComponent<IHealth>();

            if (healAble == null)
                return;

            var target = Collider2D.transform;
            ReachCollectorTarget(target, () => ReachHealedTarget(healAble));
        }

        private void ReachHealedTarget(IHealth healAble)
        {
            if (healAble == null)
                return;

            healAble.Heal(healthHeal);
        }
    }
}