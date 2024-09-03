using UnityEngine;
using UnityEngine.UI;

namespace DemonSurvivor
{
    public class PlayerWinPanel : MonoBehaviour
    {
        [SerializeField] private GameObject playerWonPanel;
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
            EventManager.StartListening(GameEvents.PlayerWon, OnPlayerWon);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.PlayerWon, OnPlayerWon);
        }

        private void OnPlayerWon(object obj)
        {
            playerWonPanel.SetActive(true);
            EventManager.TriggerEvent(GameEvents.GamePause, true);
        }
    }
}