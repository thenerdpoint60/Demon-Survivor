using UnityEngine;

namespace DemonSurvivor
{
    [CreateAssetMenu(fileName = "PositionReference", menuName = "ScriptableObjects/PositionReference", order = 1)]
    public class PositionReferenceSO : ScriptableObject
    {
        private IMovableState movableState;

        public Vector2 PositionReference => movableState.CurrentPosition;

        public void SetMovableState(IMovableState movableState)
        {
            this.movableState = movableState;
        }
    }
}