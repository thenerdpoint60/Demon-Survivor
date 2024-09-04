using UnityEngine;

namespace DemonSurvivor
{
    public abstract class MovementListener : MonoBehaviour
    {
        public abstract void OnDestinationDirectionChanged(Vector3 direction);
        public abstract void OnMovementStopped();
    }
}