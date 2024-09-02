using UnityEngine;

namespace VampireSurvivor
{
    public class OutsideTheGameArea : MonoBehaviour
    {
        public void EnemyOutsideArea(Collider2D collider2D)
        {
            collider2D.GetComponent<EnemyHealth>().ReturnToPool();
        }
    }
}