using UnityEngine;
using UnityEngine.UI;

public class ViewUpgradePanel : MonoBehaviour
{
    [Header("Добавить ссылку на объект - <<Панель улучшений>>")]
    [SerializeField] private GameObject _upgradePanel;
    [Header("Добавить ссылку на кнопку которая активирует <<Панель улучшений>>")]
    [SerializeField] private Toggle _toggle;    

    private void Awake()
    {        
        _toggle.onValueChanged.AddListener(ClickToggleUpgradePanel);        
    }

    private void ClickToggleUpgradePanel(bool valueToggle)
    {        
        _upgradePanel.SetActive(!valueToggle);
    }
}
