using UnityEngine;

namespace VampireSurvivor
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
            string upgradeText = $"INCREASE WEAPON DAMAGE FROM {currentDamage} " +
                $"<color=#00FF00><b> TO " +
                $"{newDamage}" +
                $"</b></color>";
            return upgradeText;
        }
    }
}