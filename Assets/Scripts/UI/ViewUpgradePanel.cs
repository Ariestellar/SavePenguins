using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ViewUpgradePanel : MonoBehaviour
{    
    [Header("Ссылку на шаблон <<Улучшения>> для UI")]
    [SerializeField] private GameObject _templateViewUpgrade;
    [Header("Ссылку на панель UI в которой будут находится все улучшения")]
    [SerializeField] private GameObject _upgradePanel;    
    [Header("Добавить ссылку на кнопку которая активирует <<Панель улучшений>>")]
    [SerializeField] private Toggle _toggle;

    //Cсылку на контроллер общего счетчика
    //Ссылка нужна для передачи в каждый созданный экземпляр <<Улучшения>>
    private ControllerTotalCounter _totalCounter;
    private DataImprovement[] _dataImprovements;

    public void Init(DataImprovement[] dataImprovements, ControllerTotalCounter totalCounter)
    {
        _dataImprovements = dataImprovements;
        _totalCounter = totalCounter;
        _toggle.onValueChanged.AddListener(ClickToggleUpgradePanel);
        Create();
    }
    
    private void Create()
    {
        foreach (var _data in _dataImprovements)
        {
            GameObject improvement = Instantiate(_templateViewUpgrade);
            improvement.GetComponent<RectTransform>().SetParent(_upgradePanel.transform);            
            improvement.GetComponent<ControllerImprovement>().Init(_totalCounter, _data);
        }
    }

    private void ClickToggleUpgradePanel(bool valueToggle)
    {
        _upgradePanel.SetActive(!valueToggle);
    }
}
