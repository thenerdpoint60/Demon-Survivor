using UnityEngine;

namespace DemonSurvivor
{
    public interface IUpgradeOption
    {
        public void Upgrade();
        public string ReadUpgrade();
    }
}