using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DemonSurvivor
{
    [System.Serializable]
    public class OptionUI : MonoBehaviour
    {
        [SerializeField] private Button optionButton;
        [SerializeField] private TMP_Text optionText;

        public void SetOption(IUpgradeOption upgradeOption, Action OnUpgradeSelected)
        {
            optionText.text = upgradeOption.ReadUpgrade();
            optionButton.onClick.AddListener(() =>
            {
                upgradeOption.Upgrade();
                ClearTheUpgradeOption();
                OnUpgradeSelected.Invoke();
            });
        }

        public void ClearTheUpgradeOption()
        {
            optionButton.onClick.RemoveAllListeners();
        }
    }
}