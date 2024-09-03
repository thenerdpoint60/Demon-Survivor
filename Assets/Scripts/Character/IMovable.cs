using UnityEngine;

namespace DemonSurvivor
{
    public interface IMovable
    {
        public void Move(Vector2 moveDirection);
        public void StopMoving();
    }
}