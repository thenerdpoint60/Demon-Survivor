using DG.Tweening;
using UnityEngine;

namespace VampireSurvivor
{
    public class TopDownMovement : MonoBehaviour, IMovable
    {
        [SerializeField] private Rigidbody2D characterRigidBody;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private Animator animator;

        private Tweener movementTween;

        public void Move(Vector2 moveDirection)
        {
            Vector2 targetPosition = characterRigidBody.position + moveDirection.normalized * moveSpeed;
            bool isMoving = movementTween != null && !movementTween.IsComplete();
            if (!isMoving)
            {
                movementTween = characterRigidBody.DOMove(targetPosition, moveSpeed)
                    .SetEase(ease)
                    .SetSpeedBased(true)
                    .SetAutoKill(false)
                    .Pause()
                    .OnComplete(() =>
                    {
                        Move(moveDirection);
                    });
            }

            movementTween.ChangeEndValue(targetPosition, moveSpeed, true).Restart();

            //TODO : Refactor this animator from top down.
            animator.SetBool("Moving", true);
        }

        public void StopMoving()
        {
            if (movementTween == null)
                return;

            movementTween.Kill();
            movementTween = null;
            animator.SetBool("Moving", false);
        }
    }
}