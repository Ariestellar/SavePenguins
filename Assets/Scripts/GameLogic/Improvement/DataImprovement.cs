using UnityEngine;

/// <summary>
/// Класс модель хранит в себе данные для улучшений
/// Название экземпляра является названием для улучшения
/// </summary>
[CreateAssetMenu()]
public class DataImprovement : ScriptableObject
{
    [Header("Цена")]
    [SerializeField] private float _price;
    /*[Header("На сколько увеличивается цена с каждым шагом(на 20%)")]
    [SerializeField] private float _priceIncrease = 0.2f;*/
    private float _priceIncrease = 0.2f;
    private int _currentProgress;
    [Header("Лимит прогресса улучшения")]
    [SerializeField] private int _progressLimits;    
    [Header("Количество очков добавляемых к прибыли с каждым шагом")]
    [SerializeField] private float _amountIncrease;
    [Header("Спрайт")]
    [SerializeField] private Sprite _sprite;
    /// <summary>
    /// Не достигнут ли лимит прокачки?
    /// </summary>
    private bool _onLimitReached;
    /// <summary>
    /// Хватает ли общего счета для покупки?
    /// </summary>
    private bool _purchaseOpportunity;

    #region Блок свойств для публичного использования 
    public float AmountIncrease { get => _amountIncrease; }
    public float Price { get => _price; set => _price = value; }
    public int CurrentProgress { get => _currentProgress; set => _currentProgress = value; }
    public int ProgressLimits { get => _progressLimits; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }    
    public float PriceIncrease { get => _priceIncrease; }
    public bool OnLimitReached { get => _onLimitReached; set => _onLimitReached = value; }
    public bool PurchaseOpportunity { get => _purchaseOpportunity; set => _purchaseOpportunity = value; }
    #endregion

    public void Init(float price, float priceIncrease, int progressLimits, float amountIncrease, Sprite sprite)
    {
        _price = price;
        _priceIncrease = priceIncrease;
        _progressLimits = progressLimits;
        _amountIncrease = amountIncrease;
        _sprite = sprite;
    }
}
