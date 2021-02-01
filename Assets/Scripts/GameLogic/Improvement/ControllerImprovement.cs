using UnityEngine;

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
        _data.PriceUpgrade = _data.GetPriceUpgrade(_data.PriceUnlock, _data.InitialImprovementCostPercentage, _data.CurrentProgress);
        GetComponent<ViewUpgrade>().Init(_data, Unlock, Buy);
    }

    private void Update()
    {
        if (_data != null)
        {
            _data.IsPurchaseOpportunityUpgrade = OnTotalScore(_data.PriceUpgrade);
            _data.IsPurchaseOpportunityUnlock = OnTotalScore(_data.PriceUnlock);
        }        
    }

    /// <summary>
    /// Разблокировать улучшение
    /// </summary>
    private void Unlock()
    {
        _totalCounter.SubstractPoints(_data.PriceUnlock);
        _data.IsUnlock = true; 
    }

    /// <summary>
    /// Действия при клике на кнопку купить
    /// </summary>
    private void Buy()
    {        
        _totalCounter.IncreaseCurrentProfit(_data.AmountIncrease);
        _totalCounter.SubstractPoints(_data.PriceUpgrade);
        TakeStep();
        _data.OnLimitReached = OnLimitReached(); 
    }

    /// <summary>
    /// При покупке улучшения продвигаем прогресс на n шагов
    /// </summary>
    private void TakeStep(int step = 1)
    {
        _data.CurrentProgress += step;
        _data.PriceUpgrade += (_data.PriceUpgrade * _data.PriceIncreasePercentage / 100) * step;
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
    /// Проверяем наличие достаточного колличества очков для покупки
    /// </summary>
    /// <returns>true - очков хватает</returns>
    private bool OnTotalScore(float cost)
    {
        return _totalCounter.OnTotalScore(cost);
    }
}
