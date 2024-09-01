using UnityEngine;

namespace VampireSurvivor
{
    public class PositionReferenceSetter : MonoBehaviour
    {
        [SerializeField] private PositionReferenceSO positionReference;

        private void Awake()
        {
            IMovableState movableState = GetComponent<IMovableState>();
            positionReference.SetMovableState(movableState);
        }

        private void Reset()
        {
            if (GetComponent<IMovableState>() == null)
            {
                gameObject.AddComponent<TopDownMovement>();
            }
        }
    }
}