using UnityEngine;

namespace DemonSurvivor
{
    public class CharacterMovementAnimation : MovementListener
    {
        [SerializeField] private Animator characterAnimator;

        public override void OnDestinationDirectionChanged(Vector3 direction)
        {
            if (characterAnimator != null)
                characterAnimator.SetBool("Moving", true);
        }

        public override void OnMovementStopped()
        {
            if (characterAnimator != null)
                characterAnimator.SetBool("Moving", false);
        }
    }
}