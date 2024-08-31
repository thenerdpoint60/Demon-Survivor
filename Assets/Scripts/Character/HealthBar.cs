using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivor
{
    public class HealthBar : MonoBehaviour
    {
        private Image healthFillImage;

        private void Awake()
        {
            healthFillImage = GetComponent<Image>();
        }

        private void OnEnable()
        {
            UpdateHealthBar(1);
        }

        public void UpdateHealthBar(float healthPercentage)
        {
            healthFillImage.fillAmount = healthPercentage;
        }
    }
}