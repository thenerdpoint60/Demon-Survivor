using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

namespace VampireSurvivor
{
    public class HealthUpdateText : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthUpdateText;
        [SerializeField] private float textDisplayDuration = 0.05f;

        [SerializeField] private float scaleUpFactor = 0.9f;
        [SerializeField] private float animationDuration = 0.7f;
        [SerializeField] private Ease ease = Ease.Linear;

        private Vector3 currentScale;

        private WaitForSeconds TextDisplayTimer => new WaitForSeconds(textDisplayDuration);

        private void Awake()
        {
            currentScale = healthUpdateText.transform.localScale;
        }

        public void DamageTaken(int damageValue)
        {
            healthUpdateText.text = $"<color=red>-{damageValue}</color>";
            DisplayForSeconds();
        }

        public void HealTaken(int healValue)
        {
            healthUpdateText.text = $"<color=green>+{healValue}</color>";
            DisplayForSeconds();
        }

        private void DisplayForSeconds()
        {
            StopCoroutine(DisableTextOnDelay());
            healthUpdateText.gameObject.SetActive(true);
            Transform textTransform = healthUpdateText.transform;
            textTransform.localScale = currentScale;
            textTransform.DOScale(scaleUpFactor, animationDuration / 2)
                                    .SetEase(ease)
                                    .OnComplete(() =>
                                    {
                                        StartCoroutine(DisableTextOnDelay());
                                    });
        }

        private IEnumerator DisableTextOnDelay()
        {
            yield return TextDisplayTimer;
            healthUpdateText.gameObject.SetActive(false);
        }
    }
}