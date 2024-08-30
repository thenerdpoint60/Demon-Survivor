using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace VampireSurvivor
{
    public class PlayerInput : MonoBehaviour
    {
        private IMovable playerMovable;

        private void Awake()
        {
            playerMovable = GetComponent<IMovable>();
        }

        private void Reset()
        {
            if (GetComponent<IMovable>() == null)
            {
                gameObject.AddComponent<TopDownMovement>();
            }
        }

        public void MovePlayer(CallbackContext context)
        {
            if (context.canceled)
            {
                playerMovable.StopMoving();
                return;
            }

            if (!context.performed)
                return;

            Vector2 moveDirection = context.action.ReadValue<Vector2>();
            playerMovable.Move(moveDirection);
        }
    }
}