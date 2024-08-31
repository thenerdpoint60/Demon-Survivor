using UnityEngine;

namespace VampireSurvivor
{
    [CreateAssetMenu(fileName = "ProjectileStats", menuName = "ScriptableObjects/ProjectileStats", order = 1)]
    public class ProjectileStatsSO : ScriptableObject
    {
        [SerializeField] private int speed = 5;
        [SerializeField] private int damage = 10;
        [SerializeField] private int increaseDamageBy = 5;
        [SerializeField] private float projectileDuration = 5f;

        public int Speed => speed;

        public int Damage => damage;
        public int IncreaseDamageBy => increaseDamageBy;
        public float ProjectileDuration => projectileDuration;

        public void IncreaseDamage()
        {
            damage += increaseDamageBy;
        }
    }
}