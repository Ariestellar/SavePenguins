﻿using UnityEngine;

/// <summary>
/// Класс модель, хранит данные для глобального счетчика
/// Создаем только один экземпляр оформил в ScriptableObject, а не синглтон, для удобства геймдизайна 
/// </summary>
/// 
[CreateAssetMenu()]
public class DataTotalCounter : ScriptableObject
{
    [Header("Общее колличество очков в игре")]
    [Tooltip("Сериализовал, что бы, была возможность в начале игры задать при старте")]
    [SerializeField] private float _totalScore;
    [Header("Интервал времени, через которое начисляются очки(сек)")]
    [SerializeField] private float _timeInterval;
    [Header("Текущее количество прибыли в единицу времени")]
    [Tooltip("Сериализовал, что бы, была возможность в начале игры задать при старте")]    
    [SerializeField] private float _currentAmountProfit;
    [Header("Текущее количество пингвинов в ангарах")]    
    [SerializeField] private int _currentPenguin;
    [Header("Увеличение прибыли за одного пингвина в ангаре($):")]
    [SerializeField] private float _increaseProfitPerPenguin = 0.01f;

    // Множители прибыли, не задаются вручную, а используется в контроллере, при особых событиях в игре:
    ///<summary>Множитель для ускорения и замедления времени</summary>
    private int _factorTime = 1;
    ///<summary>Множитель для увеличения прибыли</summary>
    private int _factorProfit = 1;
        
    #region Блок свойств для публичного использования 
    public float TotalScore { get => _totalScore; set => _totalScore = value; }
    public float CurrentAmountProfit { get => _currentAmountProfit; set => _currentAmountProfit = value; }
    public float TimeInterval { get => _timeInterval; }    
    public int FactorTime { get => _factorTime; }
    public int FactorProfit { get => _factorProfit; }
    public int CurrentPenguin { get => _currentPenguin; set => _currentPenguin = value; }
    public float IncreaseProfitPerPenguin { get => _increaseProfitPerPenguin; }
    #endregion
}
