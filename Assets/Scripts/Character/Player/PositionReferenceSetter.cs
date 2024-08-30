using UnityEngine;

namespace VampireSurvivor
{
    public class PositionReferenceSetter : MonoBehaviour
    {
        [SerializeField] private SPositionReference positionReference;

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