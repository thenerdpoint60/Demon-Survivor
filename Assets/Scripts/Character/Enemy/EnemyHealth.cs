using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivor
{
    public class EnemyHealth : CharacterHealth
    {
        [SerializeField] private UnityEvent<float> onHealthUpdated;
        [SerializeField] private UnityEvent onEnemyDead;
        [SerializeField] private GamePoolType poolType;
        [SerializeField] private GameObject parentTransform;
        [SerializeField] private Animator enemyAnimator;
        [SerializeField] private GamePoolType enemyDeathRewards = GamePoolType.XP;
        [SerializeField] private float deadPlayAnimationDelayInSec = 1f;

        public override void Damage(int damage)
        {
            base.Damage(damage);

            //PlayHitAnimation();
            if (HasDied())
            {
                HandleDeath();
            }

            UpdateHealthUI();
        }

        private void UpdateHealthUI()
        {
            float currentHealthPercentage = (float)GetCurrentHealth / GetMaxHealth;
            onHealthUpdated?.Invoke(currentHealthPercentage);
        }

        private void PlayHitAnimation()
        {
            enemyAnimator.SetTrigger("Hit");
        }

        private void StartMovingAnimation()
        {
            enemyAnimator.SetBool("Moving", true);
        }

        private void HandleDeath()
        {
            onEnemyDead.Invoke();
            enemyAnimator.SetTrigger("Dead");
            float animationDuration = enemyAnimator.GetCurrentAnimatorStateInfo(0).length;

            DOVirtual.DelayedCall(animationDuration + deadPlayAnimationDelayInSec, () =>
            {
                Debug.Log("Death animation completed");

                GameObject gameXP = PoolManager.Instance.GetFromPool(GamePoolType.XP);
                gameXP.transform.position = parentTransform.transform.position;

                PoolManager.Instance.ReturnToPool(poolType, parentTransform);
            });
        }
    }
}