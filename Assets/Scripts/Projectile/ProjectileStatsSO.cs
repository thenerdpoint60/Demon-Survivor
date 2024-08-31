using UnityEngine;

namespace VampireSurvivor
{
    [CreateAssetMenu(fileName = "ProjectileStats", menuName = "ScriptableObjects/ProjectileStats", order = 1)]
    public class ProjectileStatsSO : ScriptableObject
    {
        [SerializeField] private int speed = 5;
        [SerializeField] private int damage = 10;
        [SerializeField] private int increaseDamageBy = 5;

        public int Speed => speed;

        public int Damage => damage;

        public void IncreaseDamage()
        {
            damage += increaseDamageBy;
        }
    }
}