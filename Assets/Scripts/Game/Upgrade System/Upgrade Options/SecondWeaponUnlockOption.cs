using UnityEngine;

namespace VampireSurvivor
{
    public class SecondWeaponUnlockOption : UpgradeOption
    {
        [SerializeField] private GameObject secondWeapon;

        public override string ReadUpgrade()
        {
            string upgradeText = $"UNLOCK A SECOND WEAPON WITH THE FIREPOWER";
            return upgradeText;
        }

        public override void Upgrade()
        {
            isThisUpgradeMaximized = true;
            secondWeapon.SetActive(true);
        }
    }
}