using System.Collections;
using UnityEngine;

namespace VampireSurvivor
{
    public class EnemyDamage : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private float attackCooldown = 1f;
        private Coroutine damageCoroutine;

        public void StartDamaging(Collider2D collision)
        {
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(DamagePlayerCoroutine(collision));
            }
        }

        public void StopDamaging(Collider2D collision)
        {
            StopDamageCoroutine();
        }

        private IEnumerator DamagePlayerCoroutine(Collider2D collision)
        {
            IHealth damageable = collision.gameObject.GetComponent<IHealth>();
            WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(attackCooldown);
            while (damageable != null)
            {
                damageable.Damage(damage);
                yield return waitForSecondsRealtime;
            }
        }

        public void StopDamageCoroutine()
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}