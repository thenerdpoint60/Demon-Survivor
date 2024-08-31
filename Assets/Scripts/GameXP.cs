using DG.Tweening;
using UnityEngine;

namespace VampireSurvivor
{
    public class GameXP : MonoBehaviour
    {
        [SerializeField] private float moveDuration = 0.6f;
        [SerializeField] private AudioClip rewardClip;

        [SerializeField] private float scaleUpFactor = 0.9f;
        [SerializeField] private float animationDuration = 0.7f;

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
                        .SetEase(Ease.OutQuad)
                        .OnComplete(() =>
                        {
                            transform.DOScale(currentScale, animationDuration / 2).SetEase(Ease.InQuad);
                        })
                        .SetLoops(-1, LoopType.Yoyo);
        }

        public void RewardsGameXP(Collider2D collider2D)
        {
            Vector3 targetPosition = collider2D.transform.position;

            moveTween = transform.DOMove(targetPosition, moveDuration)
               .SetEase(Ease.Linear)
               .OnComplete(() =>
               {
                   if (rewardClip != null)
                       audioSource.PlayOneShot(rewardClip);
                   collider2D.GetComponent<ICollectable>().Reward();
                   PoolManager.Instance.ReturnToPool(GamePoolType.XP, gameObject);
               });
        }

        private void OnDisable()
        {
            scaleTween.Kill();
        }
    }
}