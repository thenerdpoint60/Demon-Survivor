using System;
using UnityEngine;

namespace DemonSurvivor
{
    [CreateAssetMenu(fileName = "ProjectileStats", menuName = "ScriptableObjects/ProjectileStats", order = 1)]
    public class ProjectileStatsSO : ScriptableObject
    {
        [SerializeField] private int speed = 5;
        [SerializeField] private int damage = 10;
        [SerializeField] private int increaseDamageBy = 5;
        [SerializeField] private float projectileDuration = 5f;
        [SerializeField] private int increaseSpeedBy = 5;

        private int initialDamage;

        private void OnEnable()
        {
            initialDamage = damage;
        }

        public int Speed => speed;

        public int Damage => damage;
        public int IncreaseDamageBy => increaseDamageBy;
        public int IncreaseSpeedBy => increaseSpeedBy;
        public float ProjectileDuration => projectileDuration;

        public void IncreaseDamage()
        {
            damage += increaseDamageBy;
        }

        public void IncreaseSpeed()
        {
            speed += increaseSpeedBy;
        }

        private void OnDisable()
        {
            damage = initialDamage;
        }
    }
}