using System.Collections;
using UnityEngine;

namespace VampireSurvivor
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileStatsSO stats;

        private Vector2 direction;
        private WaitForSeconds waitForSecondsBeforeSelfDestruct;

        private void Awake()
        {
            waitForSecondsBeforeSelfDestruct = new WaitForSeconds(stats.ProjectileDuration);
        }

        private void OnEnable()
        {
            StartCoroutine(SelfDestruct());
        }

        private IEnumerator SelfDestruct()
        {
            yield return waitForSecondsBeforeSelfDestruct;
            ReturnToPool();
        }

        public void SetDirection(Vector2 dir)
        {
            direction = dir.normalized;
        }

        private void Update()
        {
            MoveProjectile();
        }

        private void MoveProjectile()
        {
            transform.Translate(direction * stats.Speed * Time.deltaTime);
        }

        public void DamageEnemy(Collider2D Collider2D)
        {
            IHealth damageable = Collider2D.gameObject.GetComponent<IHealth>();
            if (damageable != null)
            {
                damageable.Damage(stats.Damage);
            }
            ReturnToPool();
        }

        private void OnDisable()
        {
            direction = Vector2.zero;
        }

        private void ReturnToPool()
        {
            PoolManager.Instance.ReturnToPool(GamePoolType.Projectile, gameObject);
        }
    }
}