using UnityEngine;

namespace VampireSurvivor
{
    public class DecreaseWeaponFireRateOption : UpgradeOption
    {
        [SerializeField] private WeaponStatsSO weaponStatsSO;

        public override string ReadUpgrade()
        {
            float currentFireRate = weaponStatsSO.FireRate;
            float nextFireRate = currentFireRate - weaponStatsSO.DecreaseFireRateBy;
            string upgradeText = $"DECREASE WEAPON FIRE RATE FROM <color=red>{currentFireRate} </color>" +
                $"<color=green><b>TO " +
                $"{nextFireRate}" +
                $"</b></color>";
            return upgradeText;
        }

        public override void Upgrade()
        {
            weaponStatsSO.DecreaseFireRate();
        }
    }
}