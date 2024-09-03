using System;
using UnityEngine;
using UnityEngine.UI;

namespace DemonSurvivor
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitGame;

        private void Start()
        {
            restartButton.onClick.AddListener(() => RestartGame());
            quitGame.onClick.AddListener(() => QuitGame());
        }

        private void QuitGame()
        {
            EventManager.TriggerEvent(GameEvents.QuitGame);
        }

        private void RestartGame()
        {
            EventManager.TriggerEvent(GameEvents.RestartGame);
        }

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.PlayerDie, OnPlayerDie);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.PlayerDie, OnPlayerDie);
        }

        private void OnPlayerDie(object obj)
        {
            gameOverPanel.SetActive(true);
            EventManager.TriggerEvent(GameEvents.GamePause, true);
        }
    }
}