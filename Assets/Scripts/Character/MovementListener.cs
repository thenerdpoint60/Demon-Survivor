using UnityEngine;

namespace VampireSurvivor
{
    public abstract class MovementListener : MonoBehaviour
    {
        public abstract void OnDestinationDirectionChanged(Vector3 direction);
        public abstract void OnMovementStopped();
    }
}