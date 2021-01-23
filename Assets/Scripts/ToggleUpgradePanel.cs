using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    private Toggle _toggle;    

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(ClickToggleUpgradePanel);        
    }

    private void ClickToggleUpgradePanel(bool valueToggle)
    {        
        _upgradePanel.SetActive(!valueToggle);
    }
}
