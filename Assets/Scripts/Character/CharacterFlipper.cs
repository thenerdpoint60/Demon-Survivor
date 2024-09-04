using UnityEngine;

namespace VampireSurvivor
{
    public class CharacterFlipper : MovementListener
    {
        [SerializeField] private Transform characterBody;
        private Vector3 characterScale;

        private void Awake()
        {
            characterScale = characterBody.localScale;
        }

        public override void OnDestinationDirectionChanged(Vector3 moveDirection)
        {
            if (moveDirection.x > 0)
                FlipCharacter(1);
            else
                FlipCharacter(-1);
        }

        private void FlipCharacter(int value)
        {
            characterScale.x = value;
            characterBody.localScale = characterScale;
        }

        public override void OnMovementStopped()
        {
            FlipCharacter(1);
        }
    }
}