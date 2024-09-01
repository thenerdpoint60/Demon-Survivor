using UnityEngine;

namespace VampireSurvivor
{
    public class UpgradeOption : MonoBehaviour, IUpgradeOption
    {
        public virtual string ReadUpgrade()
        {
            return string.Empty;
        }

        public virtual void Upgrade()
        {

        }
    }
}