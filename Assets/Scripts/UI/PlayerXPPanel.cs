using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivor
{
    public class PlayerXPPanel : MonoBehaviour
    {
        [SerializeField] private Image currentPlayerXP;
        [SerializeField] private TMP_Text currentPlayerLevelText;

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.XPCollected, OnPlayerReceivedXP);
            EventManager.StartListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.XPCollected, OnPlayerReceivedXP);
            EventManager.StopListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
        }

        private void OnPlayerLevelUp(object currentLevel)
        {
            currentPlayerLevelText.text = $"LEVEL {currentLevel}";
        }

        private void OnPlayerReceivedXP(object currentXP)
        {
            currentPlayerXP.fillAmount = (float)currentXP;
        }
    }
}