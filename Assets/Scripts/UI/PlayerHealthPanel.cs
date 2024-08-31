using System;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivor
{
    public class PlayerHealthPanel : MonoBehaviour
    {
        [SerializeField] private Image currentPlayerHealth;

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.PlayerHealth, OnPlayerHealthChange);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.PlayerHealth, OnPlayerHealthChange);
        }

        private void OnPlayerHealthChange(object currentHealth)
        {
            currentPlayerHealth.fillAmount = (float)currentHealth / 100;
        }
    }
}