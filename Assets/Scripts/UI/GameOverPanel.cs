using System;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivor
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
            Debug.Log("Quit Game");
        }

        private void RestartGame()
        {
            Debug.Log("Restart Game");
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