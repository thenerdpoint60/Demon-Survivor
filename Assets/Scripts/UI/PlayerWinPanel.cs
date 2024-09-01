using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivor
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
            Debug.Log("Quit Game");
        }

        private void RestartGame()
        {
            Debug.Log("Restart Game");
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