using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorProfit : MonoBehaviour
{
    private DataTotalCounter _data;
    private ViewTotalCounter _view;

    public void Init(DataTotalCounter data, ViewTotalCounter view)
    {
        _data = data;
        _view = view;
    }

    private void Start()
    {
        StartCoroutine(DelayAddingPoints());
    }

    /// <summary>
    /// Рекурсивная (бесконечная) корутина начисляет каждый интервал времени очки к общему счету
    /// </summary>   
    private IEnumerator DelayAddingPoints()
    {
        _view.UpdateViewTotalScore();
        yield return new WaitForSeconds(_data.TimeInterval * _data.FactorTime);
        _data.TotalScore += _data.CurrentAmountProfit * _data.FactorProfit;
        _view.UpdateViewTotalScore();

        StartCoroutine(DelayAddingPoints());
    }
}
