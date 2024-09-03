using System;
using TMPro;
using UnityEngine;

namespace DemonSurvivor
{
    public class GameTimerPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private int timerInSeconds = 300;

        private float timeRemaining;
        private bool timerRunning = false;
        private bool isGamePaused = false;

        private void Start()
        {
            StartTimer(timerInSeconds);
        }

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.PlayerDie, OnPlayerDie);
            EventManager.StartListening(GameEvents.GamePause, OnGamePause);
        }

        private void OnDisable()
        {
            EventManager.StartListening(GameEvents.PlayerDie, OnPlayerDie);
            EventManager.StartListening(GameEvents.GamePause, OnGamePause);
        }

        private void OnGamePause(object state)
        {
            isGamePaused = (bool)state;
        }

        private void OnPlayerDie(object state)
        {
            timerRunning = false;
        }

        private void Update()
        {
            if (isGamePaused)
                return;

            if (timerRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    timerText.text = FormatTime(timeRemaining);
                }
                else
                {
                    timeRemaining = 0;
                    timerRunning = false;
                    timerText.text = FormatTime(timeRemaining);
                    TimerFinished();
                }
            }
        }

        public void StartTimer(int duration)
        {
            timeRemaining = duration;
            timerRunning = true;
        }

        private string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void TimerFinished()
        {
            EventManager.TriggerEvent(GameEvents.PlayerWon);
        }
    }
}