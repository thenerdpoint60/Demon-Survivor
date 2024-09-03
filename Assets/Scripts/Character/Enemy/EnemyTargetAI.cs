using System.Collections;
using UnityEngine;

namespace DemonSurvivor
{
    public class EnemyTargetAI : MonoBehaviour
    {
        [SerializeField] private PositionReferenceSO target;
        [SerializeField] private Transform enemyTransform;
        [SerializeField] private float playerFollowUpdateDelaySec = 0.2f;

        private IMovable enemyMovable;
        private bool isFollowingPlayer = true;

        private void Awake()
        {
            enemyMovable = GetComponent<IMovable>();
        }

        private void OnEnable()
        {
            isFollowingPlayer = true;
            StartCoroutine(FollowPlayerAlways());
        }

        private void OnDisable()
        {
            isFollowingPlayer = false;
        }

        private IEnumerator FollowPlayerAlways()
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(playerFollowUpdateDelaySec);
            while (true)
            {
                yield return waitForSeconds;
                if (isFollowingPlayer)
                    FollowPlayer();
            }
        }

        private void Reset()
        {
            if (GetComponent<IMovable>() == null)
            {
                gameObject.AddComponent<TopDownMovement>();
            }
        }

        private void FollowPlayer()
        {
            if (target == null)
                return;

            Vector2 targetPosition = target.PositionReference;
            Vector2 direction = (targetPosition - (Vector2)enemyTransform.position);
            enemyMovable.Move(direction);
        }

        public void StopMovement()
        {
            isFollowingPlayer = false;
            StopCoroutine(FollowPlayerAlways());
            enemyMovable.StopMoving();
        }
    }
}