using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivor
{
    public class EnemyHealth : CharacterHealth
    {
        [SerializeField] private UnityEvent<float> onHealthUpdated;
        [SerializeField] private UnityEvent onEnemyDead;
        [SerializeField] private UnityEvent onEnemySpawn;
        [SerializeField] private GamePoolType poolType;
        [SerializeField] private GameObject parentTransform;
        [SerializeField] private Animator enemyAnimator;
        [SerializeField] private GamePoolType enemyDeathRewards = GamePoolType.XP;
        [SerializeField] private float deadPlayAnimationDelayInSec = 1f;

        private void OnEnable()
        {
            onEnemySpawn.Invoke();
            ResetHealth();
        }

        public override void Damage(int damage)
        {
            base.Damage(damage);

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

        private void StartMovingAnimation()
        {
            enemyAnimator.SetBool("Moving", true);
        }

        private void HandleDeath()
        {
            onEnemyDead.Invoke();
            enemyAnimator.SetTrigger("Dead");
            float animationDuration = enemyAnimator.GetCurrentAnimatorStateInfo(0).length;
            float disappearDelayInSec = animationDuration + deadPlayAnimationDelayInSec;

            DOVirtual.DelayedCall(disappearDelayInSec, OnDeathFinished);
        }

        private void OnDeathFinished()
        {
            GameObject gameXP = PoolManager.Instance.GetFromPool(enemyDeathRewards);
            gameXP.transform.position = parentTransform.transform.position;

            PoolManager.Instance.ReturnToPool(poolType, parentTransform);
        }

        public void ReturnToPool()
        {
            onEnemyDead.Invoke();
            PoolManager.Instance.ReturnToPool(poolType, parentTransform);
        }
    }
}