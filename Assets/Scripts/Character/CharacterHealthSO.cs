using UnityEngine;

namespace VampireSurvivor
{
    [CreateAssetMenu(fileName = "CharacterHealth", menuName = "ScriptableObjects/CharacterHealth", order = 1)]
    public class CharacterHealthSO : ScriptableObject
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int upgradeMaxHealthBy = 0;

        public int MaxHealth => maxHealth;
        public float UpgradeMaxHealthByValue => upgradeMaxHealthBy;

        public void UpgradeMaxHealth()
        {
            maxHealth += upgradeMaxHealthBy;
        }
    }
}