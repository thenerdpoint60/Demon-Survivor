using DG.Tweening;
using UnityEngine;

namespace DemonSurvivor
{
    public class GameXP : CollectableItem
    {
        [SerializeField] private int rewardValue = 10;

        public void RewardsGameXP(Collider2D collider2D)
        {
            ICollectable collectable = collider2D.GetComponent<ICollectable>();

            if (collectable == null)
                return;

            var target = collider2D.transform;
            ReachCollectorTarget(target, () => Collect(collectable));
        }

        private void Collect(ICollectable collectable)
        {
            if (collectable == null)
                return;

            collectable.Collect(rewardValue);
        }
    }
}