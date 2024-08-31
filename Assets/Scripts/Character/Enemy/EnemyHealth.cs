using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivor
{
    public class EnemyHealth : CharacterHealth
    {
        [SerializeField] private UnityEvent<float> onHealthUpdated;
        [SerializeField] private GamePoolType poolType;
        [SerializeField] private GameObject parentTransform;
        [SerializeField] private Animator enemyAnimator;

        public override void Damage(int damage)
        {
            base.Damage(damage);
            UpdateHealthUI();

            PlayHitAnimation();
            if (HasDied())
            {
                HandleDeath();
            }
            else
            {
                StartMovingAnimation();
            }
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
            enemyAnimator.SetTrigger("Died");

            GameObject gameXP = PoolManager.Instance.GetFromPool(GamePoolType.XP);
            gameXP.transform.position = parentTransform.transform.position;

            PoolManager.Instance.ReturnToPool(poolType, parentTransform);
        }
    }
}