using System.Collections;
using UnityEngine;

/// <summary>
/// Класс отвечает за обработку данных глобального счетчика
/// </summary>
public class ControllerTotalCounter: MonoBehaviour
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

    /// <summary>
    /// Прирост прибыли, при прокачке улучшения
    /// </summary>
    /// <param name="increase">Количество очков прибавляемое, к текущей прибыли</param>
    public void IncreaseCurrentProfit(int increase)
    {  
        _data.CurrentAmountProfit += increase;
        _view.UpdateViewProfit();
    }

    /// <summary>
    /// Отнимаем очки затраченные на покупку улучшения из общего счета
    /// </summary>
    /// <param name="points">Колличество отнимаемых очков из общего счета</param>
    public void SubstractPoints(int points)
    {        
        _data.TotalScore -= points;
        _view.UpdateViewTotalScore();
    }

    /// <summary>
    /// Проверяем достаточно ли очков общего счета для покупки улучшения 
    /// </summary>
    /// <param name="price">Стоимость улучшения</param>
    /// <returns>true-достаточно/false-недостаточно</returns>
    public bool OnTotalScore(int price)
    {
        return _data.TotalScore < price ? false : true;
    }
}