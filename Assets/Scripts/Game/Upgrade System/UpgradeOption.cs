using UnityEngine;

namespace DemonSurvivor
{
    public class UpgradeOption : MonoBehaviour, IUpgradeOption
    {
        protected bool isThisUpgradeMaximized = false;

        public bool IsThisUpgradeMaximized => isThisUpgradeMaximized;

        public virtual string ReadUpgrade()
        {
            return string.Empty;
        }

        public virtual void Upgrade()
        {

        }
    }
}