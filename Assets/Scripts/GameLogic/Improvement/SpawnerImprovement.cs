using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerImprovement : MonoBehaviour
{
    [Header("Cсылку на контроллер общего счетчика")]
    [Tooltip("Ссылка нужна для передачи в каждый созданный экземпляр <<Улучшения>>")]
    [SerializeField] private ControllerTotalCounter _totalCounter;  
    [Header("Ссылку на шаблон <<Улучшения>> для UI")]
    [SerializeField] private GameObject _templateImproventsView;
    [Header("Ссылку на панель UI в которой будут находится все улучшения")]
    [SerializeField] private Transform _parent;

    private DataImprovement[] _dataImprovements;

    private void Awake()
    {        
        _dataImprovements = Resources.LoadAll<DataImprovement>("DataImprovement/");        
    }
    
    private void Start()
    {
        foreach (var _data in _dataImprovements)
        {
            GameObject improvement = Instantiate(_templateImproventsView);
            improvement.GetComponent<RectTransform>().SetParent(_parent.transform);            
            improvement.GetComponent<ControllerImprovement>().Init(_totalCounter, _data);
        }
    }
}
