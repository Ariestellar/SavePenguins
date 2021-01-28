using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс отвечает за обработку команд от пользователя и бизнес логику
/// </summary>
[RequireComponent(typeof(ViewUpgrade))]
public class ControllerImprovement : MonoBehaviour
{
    [SerializeField] private ControllerTotalCounter _totalCounter;
    [SerializeField] private DataImprovement _data;              
    
    public void Init(ControllerTotalCounter controllerTotalCounter, DataImprovement data)
    {        
        _totalCounter = controllerTotalCounter;
        _data = data;
        GetComponent<ViewUpgrade>().Init(_data, Buy);

    }

    private void Update()
    {
        if(_data != null)
        _data.PurchaseOpportunity = OnTotalScore();
    }

    /// <summary>
    /// Действия при клике на кнопку купить
    /// </summary>
    private void Buy()
    {        
        _totalCounter.IncreaseCurrentProfit(_data.AmountIncrease);
        _totalCounter.SubstractPoints(_data.Price);
        TakeStep();
        _data.OnLimitReached = OnLimitReached();      
    }

    /// <summary>
    /// При покупке улучшения продвигаем прогресс на n шагов
    /// </summary>
    private void TakeStep(int step = 1)
    {
        _data.CurrentProgress += step;
        _data.Price *= _data.PriceIncrease * step;        
    }

    /// <summary>
    /// Проверка достижения лимита прогресса
    /// </summary>
    /// <returns>true - лимит достигнут</returns>
    private bool OnLimitReached()
    {
        return _data.CurrentProgress >= _data.ProgressLimits ? true : false;
    }

    /// <summary>
    /// Проверяем наличие достаточного колличества очков для покупки улучшения
    /// </summary>
    /// <returns>true - очков хватает</returns>
    private bool OnTotalScore()
    {
        return _totalCounter.OnTotalScore(_data.Price);
    }
}
