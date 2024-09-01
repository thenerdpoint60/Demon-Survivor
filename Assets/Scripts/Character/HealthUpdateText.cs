using System.Collections;
using TMPro;
using UnityEngine;

namespace VampireSurvivor
{
    public class HealthUpdateText : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthUpdateText;
        [SerializeField] private float textDisplayDuration;

        private WaitForSeconds TextDisplayTimer => new WaitForSeconds(textDisplayDuration);

        public void DamageTaken(int damageValue)
        {
            healthUpdateText.text = $"<color=red>-{damageValue}</color>";
            StartCoroutine(DisplayTextForSeconds());
        }

        public void HealTaken(int healValue)
        {
            healthUpdateText.text = $"<color=green>+{healValue}</color>";
            StartCoroutine(DisplayTextForSeconds());
        }

        private IEnumerator DisplayTextForSeconds()
        {
            healthUpdateText.gameObject.SetActive(true);
            yield return TextDisplayTimer;
            healthUpdateText.gameObject.SetActive(false);
        }
    }
}