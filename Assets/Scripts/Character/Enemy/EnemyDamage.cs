using UnityEngine;

namespace VampireSurvivor
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private int damage = 10;

        //TODO : Make this as acourptine when triggered starts damaging player and stops when the player has exited the trigger.
        public void DamagePlayer(Collider2D collision)
        {
            IHealth damageable = collision.gameObject.GetComponent<IHealth>();
            if (damageable != null)
            {
                damageable.Damage(damage);
            }
        }
    }
}