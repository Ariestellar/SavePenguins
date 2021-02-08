using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Отвечает за отображение глобального счетчика игры (кол-во пингвинов, общее количество денег, текущая прибыль)
/// Для удобства отображения округляются
/// </summary>
public class ViewTotalCounter : MonoBehaviour
{    
    [Header("Установить ссылку на текст общего счета")]
    [SerializeField] private Text _textTotalScore;
    [Header("Установить ссылку на текст количество прибыли")]
    [SerializeField] private Text _textProfit;
    [Header("Установить ссылку на текст количество пингвинов")]
    [SerializeField] private Text _textCountPinguins;

    private DataTotalCounter _data;

    public void Init(DataTotalCounter data)
    {
        _data = data;
    }

    void Start()
    {
        UpdateViewTotalScore();
        UpdateViewProfit();
        UpdateViewCountPenguins();
    }

    public void UpdateViewTotalScore()
    {
        _textTotalScore.text = Convert.ToString(Mathf.Round(_data.TotalScore));        
    }

    public void UpdateViewProfit()
    {
        _textProfit.text = Convert.ToString(Mathf.Round(_data.CurrentAmountProfit) + "$ / s");
    }

    public void UpdateViewCountPenguins()
    {
        _textCountPinguins.text = Convert.ToString(_data.CurrentPenguin);
    }
}
