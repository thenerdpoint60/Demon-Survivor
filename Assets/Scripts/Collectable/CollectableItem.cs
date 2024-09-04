using DG.Tweening;
using System;
using UnityEngine;

namespace DemonSurvivor
{
    public class CollectableItem : MonoBehaviour
    {
        [SerializeField] private GamePoolType gamePoolType;
        [SerializeField] private float moveDuration = 0.6f;
        [SerializeField] private Ease moveEase = Ease.Linear;
        [SerializeField] private float animationDuration = 0.7f;
        [SerializeField] private float scaleUpFactor = 0.9f;
        [SerializeField] private Ease scaleUpEase = Ease.Linear;
        [SerializeField] private AudioClip rewardClip;

        private Tweener moveTween;
        private Tween scaleTween;
        private Vector3 currentScale;
        private AudioSource audioSource;


        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            currentScale = transform.localScale;
        }

        private void OnEnable()
        {
            StartScaleAnimation();
        }

        private void OnDisable()
        {
            StopScaleUpAnimation();
        }


        protected void ReachCollectorTarget(Transform target, Action onComplete = null)
        {
            StopScaleUpAnimation();
            Vector3 targetPosition = target.position;

            moveTween = transform.DOMove(targetPosition, moveDuration)
               .SetEase(moveEase)
               .OnComplete(() => OnCollectorTargetReached(onComplete));
        }

        private void StartScaleAnimation()
        {
            StopScaleUpAnimation();
            scaleTween = transform.DOScale(scaleUpFactor, animationDuration / 2)
                        .SetEase(scaleUpEase)
                        .SetLoops(-1, LoopType.Yoyo);
        }

        private void OnCollectorTargetReached(Action onComplete = null)
        {
            if (rewardClip != null)
                audioSource.PlayOneShot(rewardClip);

            onComplete?.Invoke();
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            PoolManager.Instance.ReturnToPool(gamePoolType, gameObject);
        }

        private void StopScaleUpAnimation()
        {
            if (moveTween == null)
                return;

            scaleTween.Kill();
            scaleTween = null;
        }
    }
}