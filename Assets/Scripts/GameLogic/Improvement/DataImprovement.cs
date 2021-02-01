using UnityEngine;

/// <summary>
/// Класс модель хранит в себе данные для улучшений
/// Название экземпляра является названием для улучшения
/// </summary>
[CreateAssetMenu()]
public class DataImprovement : ScriptableObject
{
    [Header("Стоимость разблокировки улучшения")]
    [SerializeField] private float _priceUnlock;
    [Header("Начальная стоимостью улучшений (в % от стоимости разблокировки)")]
    [Range(0, 100)][SerializeField] private float _initialImprovementCostPercentage;
    [Header("На сколько увеличивается цена с каждым шагом (в % от текущей цены улучшения)")]
    [Range(0, 100)][SerializeField] private float _priceIncreasePercentage;        
    [Header("Лимит прогресса улучшения")]
    [SerializeField] private int _progressLimits;    
    [Header("Количество очков добавляемых к прибыли с каждым шагом")]
    [SerializeField] private float _amountIncrease;
    [Header("Спрайт")]
    [SerializeField] private Sprite _sprite;    

    /// <summary>
    /// Цена апгрейда улучшения (получаем ее высчитывая процент от стоимости разблокировки)
    /// </summary>    
    private float _priceUpgrade;
    /// <summary>
    /// Текущий уровень улучшения
    /// </summary>
    private int _currentProgress;
    /// <summary>
    /// Разблокированно ли умение?
    /// </summary>
    [SerializeField] private bool _isUnlock;//TODO: 
    /// <summary>
    /// Не достигнут ли лимит прокачки?
    /// </summary>
    private bool _onLimitReached;
    /// <summary>
    /// Хватает ли общего счета для разблокировки?
    /// </summary>
    private bool _isPurchaseOpportunityUnlock;
    /// <summary>
    /// Хватает ли общего счета для покупки улучшения?
    /// </summary>
    private bool _isPurchaseOpportunityUpgrade;


    public bool TestBool;//? почему данные сбрасываются?
    #region Блок свойств для публичного использования 
    public float AmountIncrease { get => _amountIncrease; }
    public float PriceUpgrade { get => _priceUpgrade; set => _priceUpgrade = value; }
    public int CurrentProgress { get => _currentProgress; set => _currentProgress = value; }
    public int ProgressLimits { get => _progressLimits; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }    
    public float PriceIncreasePercentage { get => _priceIncreasePercentage; }
    public bool OnLimitReached { get => _onLimitReached; set => _onLimitReached = value; }
    public bool IsUnlock { get => _isUnlock; set => _isUnlock = value; }
    public float PriceUnlock { get => _priceUnlock;}
    public float InitialImprovementCostPercentage { get => _initialImprovementCostPercentage;}
    public bool IsPurchaseOpportunityUpgrade { get => _isPurchaseOpportunityUpgrade; set => _isPurchaseOpportunityUpgrade = value; }
    public bool IsPurchaseOpportunityUnlock { get => _isPurchaseOpportunityUnlock; set => _isPurchaseOpportunityUnlock = value; }
    #endregion

    public void Init(float priceUnlock, float initialImprovementCostPercentage, float priceIncreasePercentage, int progressLimits, float amountIncrease, Sprite sprite)
    {
        _priceUnlock = priceUnlock;
        _initialImprovementCostPercentage = initialImprovementCostPercentage;
        _priceUpgrade = GetPriceUpgrade(_priceUnlock, _initialImprovementCostPercentage);
        _priceIncreasePercentage = priceIncreasePercentage;
        _progressLimits = progressLimits;
        _amountIncrease = amountIncrease;
        _sprite = sprite;
    }

    /// <summary>
    /// Рассчет первоначального апгрейда является процентом от стоимости разблокировки в зависимости от уровня прогресса
    /// </summary>
    /// <param name="priceUnlock">Стоимость разблокировки</param>
    /// <param name="initialImprovementCostPercentage">Проценты от стоимости разблокировки</param>
    /// <param name="currentProgress">Текущий уровень прогресса улучшения, по умолчанию 0 т.е. самый начальный уровень</param>
    /// <returns>Получаем стоимость апгрейда</returns>
    public float GetPriceUpgrade(float priceUnlock, float initialImprovementCostPercentage, int currentProgress = 0)
    {        
        if (currentProgress > 0)
        {
            float priceUpgrade = 0;
            for (int i = 0; i < currentProgress; i++)
            {
                priceUpgrade += priceUnlock * initialImprovementCostPercentage / 100;
            }
            return priceUpgrade;
        }
        else
        {            
            return priceUnlock * initialImprovementCostPercentage / 100;
        }        
    }
}
