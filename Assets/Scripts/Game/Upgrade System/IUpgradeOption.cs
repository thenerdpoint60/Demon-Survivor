using UnityEngine;

namespace VampireSurvivor
{
    public interface IUpgradeOption
    {
        public void Upgrade();
        public string ReadUpgrade();
    }
}