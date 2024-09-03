using UnityEngine;
using UnityEngine.Events;

namespace DemonSurvivor
{
    public class Trigger2DListener : MonoBehaviour
    {
        [SerializeField] private LayerMask collisionLayers;
        [SerializeField] private UnityEvent<Collider2D> onTriggerEnter2DEvents;
        [SerializeField] private UnityEvent<Collider2D> onTriggerExit2DEvents;

        private void Reset()
        {
            var collider2D = GetComponent<Collider2D>();

            if (!collider2D)
                gameObject.AddComponent<CircleCollider2D>();
        }


        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!IsInLayerMask(col.gameObject, collisionLayers))
                return;

            onTriggerEnter2DEvents.Invoke(col);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!IsInLayerMask(col.gameObject, collisionLayers))
                return;

            onTriggerExit2DEvents.Invoke(col);
        }

        private bool IsInLayerMask(GameObject obj, LayerMask mask)
        {
            return (((1 << obj.layer) & mask) != 0);
        }
    }
}