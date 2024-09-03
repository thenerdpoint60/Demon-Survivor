using UnityEngine;

namespace VampireSurvivor
{
    public class IncreaseBulletSpeedOption : UpgradeOption
    {
        [SerializeField] private ProjectileStatsSO projectileStatsSO;

        public override string ReadUpgrade()
        {
            int currentSpeed = projectileStatsSO.Speed;
            int newSpeed = currentSpeed + projectileStatsSO.IncreaseSpeedBy;
            string upgradeText = $"INCREASE BULLET SPEED FROM <color=red>{currentSpeed} </color>" +
                $"<color=green><b>TO " +
                $"{newSpeed}" +
                $"</b></color>";
            return upgradeText;
        }

        public override void Upgrade()
        {
            projectileStatsSO.IncreaseSpeed();
        }
    }
}