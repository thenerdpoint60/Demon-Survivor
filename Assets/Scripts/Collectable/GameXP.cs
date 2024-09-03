using DG.Tweening;
using UnityEngine;

namespace DemonSurvivor
{
    public class GameXP : MonoBehaviour
    {
        [SerializeField] private int rewardValue = 10;
        [SerializeField] private float moveDuration = 0.6f;
        [SerializeField] private AudioClip rewardClip;

        [SerializeField] private float scaleUpFactor = 0.9f;
        [SerializeField] private float animationDuration = 0.7f;
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private GamePoolType rewardType = GamePoolType.XP;

        private AudioSource audioSource;
        private Tweener moveTween;
        private Tween scaleTween;
        private Vector3 currentScale;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            currentScale = transform.localScale;
        }

        private void Start()
        {
            if (moveTween != null)
                moveTween.Kill();

            scaleTween = transform.DOScale(scaleUpFactor, animationDuration / 2)
                        .SetEase(ease)
                        .OnComplete(() =>
                        {
                            transform.DOScale(currentScale, animationDuration / 2).SetEase(ease);
                        })
                        .SetLoops(-1, LoopType.Yoyo);
        }

        public void RewardsGameXP(Collider2D collider2D)
        {
            Vector3 targetPosition = collider2D.transform.position;
            ICollectable collectable = collider2D.GetComponent<ICollectable>();
            if (collectable == null)
                return;

            if (scaleTween != null)
                scaleTween.Kill();

            audioSource.PlayOneShot(rewardClip);
            collectable.Collect(rewardValue);

            moveTween = transform.DOMove(targetPosition, moveDuration)
               .SetEase(Ease.Linear)
               .OnComplete(() => OnMoveComplete(collectable));
        }

        private void OnMoveComplete(ICollectable collectable)
        {
            PoolManager.Instance.ReturnToPool(rewardType, gameObject);
        }

        private void OnDisable()
        {
            scaleTween.Kill();
            moveTween.Kill();
        }
    }
}