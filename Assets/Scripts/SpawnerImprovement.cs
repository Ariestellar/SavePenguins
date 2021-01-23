using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerImprovement : MonoBehaviour
{
    [SerializeField] private ControllerTotalCounter _totalCounter;
    [SerializeField] private DataImprovement[] _dataImprovements;
    [SerializeField] private GameObject _templateImproventsView;
    [SerializeField] private Transform _parent;

    private void Awake()
    {        
        _dataImprovements = Resources.LoadAll<DataImprovement>("");        
    }
    
    private void Start()
    {
        foreach (var _data in _dataImprovements)
        {
            GameObject improvement = Instantiate(_templateImproventsView);
            improvement.GetComponent<RectTransform>().SetParent(_parent.transform);
            //improvement.transform.parent = _parent.transform;
            improvement.GetComponent<ControllerImprovement>().Init(_totalCounter, _data);
        }
    }
}
