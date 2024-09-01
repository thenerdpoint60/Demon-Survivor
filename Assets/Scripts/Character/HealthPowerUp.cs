using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

namespace VampireSurvivor
{
    public class HealthPowerUp : MonoBehaviour
    {
        [SerializeField] private int healthHeal = 10;
        [SerializeField] private GamePoolType gamePoolType = GamePoolType.SmallHealth;

        [SerializeField] private float moveDuration = 0.6f;
        [SerializeField] private AudioClip rewardClip;

        [SerializeField] private float scaleUpFactor = 0.9f;
        [SerializeField] private float animationDuration = 0.7f;
        [SerializeField] private Ease ease = Ease.Linear;

        private AudioSource audioSource;
        private Tweener moveTween;
        private Tween scaleTween;
        private Vector3 currentScale;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            currentScale = transform.localScale;
        }

        private void OnEnable()
        {
            scaleTween = transform.DOScale(scaleUpFactor, animationDuration / 2)
                        .SetEase(ease)
                        .OnComplete(() =>
                        {
                            transform.DOScale(currentScale, animationDuration / 2).SetEase(ease);
                        })
                        .SetLoops(-1, LoopType.Yoyo);
        }

        public void Heal(Collider2D Collider2D)
        {
            Vector3 targetPosition = Collider2D.transform.position;

            IHealth healAble = Collider2D.gameObject.GetComponent<IHealth>();
            if (healAble != null)
            {
                moveTween = transform.DOMove(targetPosition, moveDuration)
                   .SetEase(Ease.Linear)
                   .OnComplete(() =>
                   {
                       if (rewardClip != null)
                           audioSource.PlayOneShot(rewardClip);

                       healAble.Heal(healthHeal);
                       ReturnToPool();
                   });
            }

        }

        private void ReturnToPool()
        {
            PoolManager.Instance.ReturnToPool(gamePoolType, gameObject);
        }

        private void OnDisable()
        {
            scaleTween.Kill();
        }
    }
}