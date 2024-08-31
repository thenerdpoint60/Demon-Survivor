using DG.Tweening;
using System;
using UnityEngine;

namespace VampireSurvivor
{
    public class TopDownMovement : MonoBehaviour, IMovable, IMovableState
    {
        [SerializeField] private Rigidbody2D characterRigidBody;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Ease ease = Ease.Linear;
        [SerializeField] private Animator animator;

        private Tweener movementTween;
        private bool pauseMovement = false;

        public Vector2 CurrentPosition => characterRigidBody.position;

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.GamePause, OnGamePauseStateChange);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.GamePause, OnGamePauseStateChange);
        }

        private void OnGamePauseStateChange(object obj)
        {
            pauseMovement = (bool)obj;
        }

        public void Move(Vector2 moveDirection)
        {
            if (pauseMovement)
                return;

            Vector2 targetPosition = CurrentPosition + moveDirection.normalized * moveSpeed;
            bool isMoving = movementTween != null && !movementTween.IsComplete();
            if (!isMoving)
            {
                movementTween = characterRigidBody.DOMove(targetPosition, moveSpeed)
                    .SetEase(ease)
                    .SetSpeedBased(true)
                    .SetAutoKill(false)
                    .Pause();
            }
            movementTween.OnComplete(() =>
            {
                Move(moveDirection);
            });

            movementTween.ChangeEndValue(targetPosition, moveSpeed, true).Restart();

            //TODO : Refactor this animator from top down.
            if (animator != null)
                animator.SetBool("Moving", true);
        }

        public void StopMoving()
        {
            if (movementTween == null)
                return;

            movementTween.Kill();
            movementTween = null;

            if (animator != null)
                animator.SetBool("Moving", false);
        }
    }
}