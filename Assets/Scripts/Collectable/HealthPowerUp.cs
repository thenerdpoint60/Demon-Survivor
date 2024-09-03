using DG.Tweening;
using UnityEngine;

namespace DemonSurvivor
{
    public class HealthPowerUp : MonoBehaviour
    {
        [SerializeField] private int healthHeal = 10;
        [SerializeField] private GamePoolType gamePoolType = GamePoolType.SmallHealth;

        [SerializeField] private float moveDuration = 0.6f;
        [SerializeField] private AudioClip rewardClip;

        [SerializeField] private float scaleUpFactor = 0.9f;
        [SerializeField] private float animationDuration = 0.7f;
        [SerializeField] private Ease animationEase = Ease.Linear;

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
            if (moveTween != null)
                moveTween.Kill();

            StartScaleAnimation();
        }

        private void StartScaleAnimation()
        {
            scaleTween = transform.DOScale(scaleUpFactor, animationDuration / 2)
                        .SetEase(animationEase)
                        .OnComplete(() =>
                        {
                            transform.DOScale(currentScale, animationDuration / 2).SetEase(animationEase);
                        })
                        .SetLoops(-1, LoopType.Yoyo);
        }

        public void Heal(Collider2D Collider2D)
        {
            Vector3 targetPosition = Collider2D.transform.position;

            IHealth healAble = Collider2D.gameObject.GetComponent<IHealth>();
            if (healAble == null)
                return;

            if (scaleTween != null)
                scaleTween.Kill();

            audioSource.PlayOneShot(rewardClip);
            healAble.Heal(healthHeal);

            moveTween = transform.DOMove(targetPosition, moveDuration)
               .SetEase(animationEase)
               .OnComplete(() => OnMoveComplete(healAble));
        }

        private void OnMoveComplete(IHealth healAble)
        {
            ReturnToPool();
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