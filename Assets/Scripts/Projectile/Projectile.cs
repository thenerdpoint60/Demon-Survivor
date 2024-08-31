using UnityEngine;

namespace VampireSurvivor
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileStatsSO stats;

        private Vector2 direction;

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

        public void DamageEnemy(Collider2D collision)
        {
            IHealth damageable = collision.gameObject.GetComponent<IHealth>();
            if (damageable != null)
            {
                damageable.Damage(stats.Damage);
                PoolManager.Instance.ReturnToPool(GamePoolType.Projectile, gameObject);
            }
        }

        private void OnDisable()
        {
            direction = Vector2.zero;
        }
    }
}