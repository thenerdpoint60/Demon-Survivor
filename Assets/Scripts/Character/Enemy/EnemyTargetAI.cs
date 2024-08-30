using System.Collections;
using UnityEngine;

namespace VampireSurvivor
{
    public class EnemyTargetAI : MonoBehaviour
    {
        [SerializeField] private SPositionReference target;
        [SerializeField] private Transform enemyTransform;

        private IMovable enemyMovable;

        private void Awake()
        {
            enemyMovable = GetComponent<IMovable>();
        }

        private void Start()
        {
            //TODO : Make a courotine
            InvokeRepeating(nameof(FollowPlayer), 0, 0.1f);
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
    }
}