using UnityEngine;

namespace DemonSurvivor
{
    public class PlayerHealthUpgradeOption : UpgradeOption
    {
        [SerializeField] private CharacterHealthSO playerHealthSO;
        [SerializeField] private PlayerHealth playerHealth;

        public override string ReadUpgrade()
        {
            int maxHealth = playerHealthSO.MaxHealth;
            int nextMaxHealth = (int)(maxHealth + playerHealthSO.UpgradeMaxHealthByValue);
            string upgradeText = $"INCREASE MAX HEALTH FROM <color=red>{maxHealth} </color>" +
                $"<color=green><b>TO" +
                $"{nextMaxHealth}" +
                $"</b></color>";
            return upgradeText;
        }

        public override void Upgrade()
        {
            playerHealthSO.UpgradeMaxHealth();
            playerHealth.Heal(playerHealthSO.MaxHealth);
        }
    }
}