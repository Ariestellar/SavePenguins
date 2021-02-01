using System.Collections;
using UnityEngine;

/// <summary>
/// Класс отвечает за обработку данных глобального счетчика (кол-во пингвинов, общее количество денег, текущая прибыль)
/// </summary>
public class ControllerTotalCounter
{         
    private DataTotalCounter _data;
    private ViewTotalCounter _view;

    public ControllerTotalCounter(DataTotalCounter data, ViewTotalCounter view)
    {        
        _data = data;
        _view = view;
    }    

    /// <summary>
    /// Прирост прибыли, при прокачке улучшения
    /// </summary>
    /// <param name="increase">Количество очков прибавляемое, к текущей прибыли</param>
    public void IncreaseCurrentProfit(float increase)
    {  
        _data.CurrentAmountProfit += increase;
        _view.UpdateViewProfit();
    }

    /// <summary>
    /// Увеличить колличество пингвинов
    /// </summary>    
    public void IncreaseCountPenguins()
    {
        _data.CurrentPenguin += 1;
        IncreaseCurrentProfit(_data.IncreaseProfitPerPenguin);
        _view.UpdateViewCountPenguins();
    }

    /// <summary>
    /// Отнимаем очки затраченные на покупку улучшения из общего счета
    /// </summary>
    /// <param name="points">Колличество отнимаемых очков из общего счета</param>
    public void SubstractPoints(float points)
    {        
        _data.TotalScore -= points;
        _view.UpdateViewTotalScore();       
    }

    /// <summary>
    /// Проверяем достаточно ли очков общего счета для покупки улучшения 
    /// </summary>
    /// <param name="price">Стоимость для сравнения с общим счетом</param>
    /// <returns>true-достаточно/false-недостаточно</returns>
    public bool OnTotalScore(float price)
    {
        return _data.TotalScore < price ? false : true;
    }
}