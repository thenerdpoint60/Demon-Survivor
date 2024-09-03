using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DemonSurvivor
{
    public class SceneManager : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.QuitGame, OnGameQuit);
            EventManager.StartListening(GameEvents.RestartGame, OnRestartGame);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.QuitGame, OnGameQuit);
            EventManager.StopListening(GameEvents.RestartGame, OnRestartGame);
        }

        private void OnRestartGame(object obj)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        private void OnGameQuit(object obj)
        {
#if UNITY_STANDALONE_WIN
            Application.Quit();
#endif
        }
    }
}