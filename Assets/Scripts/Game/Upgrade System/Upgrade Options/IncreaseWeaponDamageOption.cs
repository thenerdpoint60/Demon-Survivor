using UnityEngine;

namespace DemonSurvivor
{
    public class IncreaseWeaponDamageOption : UpgradeOption
    {
        [SerializeField] private ProjectileStatsSO projectileStatsSO;

        public override void Upgrade()
        {
            projectileStatsSO.IncreaseDamage();
        }

        public override string ReadUpgrade()
        {
            int currentDamage = projectileStatsSO.Damage;
            int newDamage = currentDamage + projectileStatsSO.IncreaseDamageBy;
            string upgradeText = $"INCREASE WEAPON DAMAGE FROM <color=red>{currentDamage} </color>" +
                $"<color=green><b>TO " +
                $"{newDamage}" +
                $"</b></color>";
            return upgradeText;
        }
    }
}