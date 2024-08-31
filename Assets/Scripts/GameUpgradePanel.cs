using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivor
{
    public class GameUpgradePanel : MonoBehaviour
    {
        [SerializeField] private GameObject upgradePanel;

        [Header("Player Health Upgrade")]
        [SerializeField] private CharacterHealthSO playerHealthSO;
        [SerializeField] private Button playerHealthUpgradeButton;
        [SerializeField] private TMP_Text playerHealthUpgradeText;

        [Header("Weapon Damage Upgrade")]
        [SerializeField] private ProjectileStatsSO projectileStatsSO;
        [SerializeField] private Button weaponDamageUpgrade;
        [SerializeField] private TMP_Text weaponDamageUpgradeText;

        [Header("Weapon Fire Upgrade")]
        [SerializeField] private WeaponStatsSO weaponStatsSO;
        [SerializeField] private Button weaponFireRateUpgrade;
        [SerializeField] private TMP_Text weaponFireRateUpgradeText;

        private void Start()
        {
            InitializeUpgradeButtons();
        }

        private void InitializeUpgradeButtons()
        {
            playerHealthUpgradeButton.onClick.AddListener(() => UpgradePlayerHealth());
            weaponDamageUpgrade.onClick.AddListener(() => UpgradeWeaponDamage());
            weaponFireRateUpgrade.onClick.AddListener(() => UpgradeWeaponFireRate());
        }

        private void OnEnable()
        {
            EventManager.StartListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
        }

        private void SetUpUpgradePanel()
        {
            playerHealthUpgradeButton.gameObject.SetActive(true);
            playerHealthUpgradeText.text = $"INCREASE MAX HEALTH FROM {playerHealthSO.MaxHealth} <color=#00FF00><b> TO {playerHealthSO.MaxHealth + playerHealthSO.UpgradeMaxHealthBy}</b></color>";
            if (playerHealthSO.CurrentHealth >= playerHealthSO.MaxHealth)
                playerHealthUpgradeButton.gameObject.SetActive(false);

            weaponDamageUpgradeText.text = $"INCREASE WEAPON DAMAGE {projectileStatsSO.Damage} <color=#00FF00><b> TO {projectileStatsSO.Damage + projectileStatsSO.IncreaseDamageBy}</b></color>";

            weaponFireRateUpgrade.gameObject.SetActive(true);
            weaponFireRateUpgradeText.text = $"DECREASE FIRE COOLDOWN {weaponStatsSO.FireRate} <color=#00FF00><b> TO {weaponStatsSO.FireRate + weaponStatsSO.DecreaseFireRateBy}</b></color>";
            if (weaponStatsSO.FireRate <= 0.1f)
                weaponFireRateUpgrade.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            EventManager.StopListening(GameEvents.PlayerLevelUp, OnPlayerLevelUp);
        }

        private void OnPlayerLevelUp(object obj)
        {
            SetUpUpgradePanel();
            upgradePanel.SetActive(true);
            ToggleGamePauseState(true);
        }

        private void UpgradePlayerHealth()
        {
            playerHealthSO.UpgradeMaxHealth();
            upgradePanel.SetActive(false);
            ToggleGamePauseState(false);
        }

        private void UpgradeWeaponDamage()
        {
            projectileStatsSO.IncreaseDamage();
            upgradePanel.SetActive(false);
            ToggleGamePauseState(false);
        }

        private void UpgradeWeaponFireRate()
        {
            weaponStatsSO.DecreaseFireRate();
            upgradePanel.SetActive(false);
            ToggleGamePauseState(false);
        }

        private void ToggleGamePauseState(bool state)
        {
            EventManager.TriggerEvent(GameEvents.GamePause, state);
        }
    }
}