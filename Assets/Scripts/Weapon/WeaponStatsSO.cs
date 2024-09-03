using UnityEngine;

namespace DemonSurvivor
{
    [CreateAssetMenu(fileName = "WeaponStats", menuName = "ScriptableObjects/WeaponStats", order = 1)]
    public class WeaponStatsSO : ScriptableObject
    {
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private float decreaseFireRateBy = 0.2f;

        public float FireRate => fireRate;
        public float DecreaseFireRateBy => decreaseFireRateBy;

        public void DecreaseFireRate()
        {
            fireRate -= decreaseFireRateBy;
        }
    }
}