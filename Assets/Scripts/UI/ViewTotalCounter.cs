using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewTotalCounter : MonoBehaviour
{    
    [Header("Установить ссылку на текст общего счета")]
    [SerializeField] private Text _textTotalScore;
    [Header("Установить ссылку на текст количество прибыли")]
    [SerializeField] private Text _textProfit;

    private DataTotalCounter _data;

    public void Init(DataTotalCounter data)
    {
        _data = data;
    }

    void Start()
    {
        UpdateViewTotalScore();
        UpdateViewProfit();        
    }

    public void UpdateViewTotalScore()
    {
        _textTotalScore.text = Convert.ToString(_data.TotalScore);        
    }

    public void UpdateViewProfit()
    {
        _textProfit.text = Convert.ToString(_data.CurrentAmountProfit + "$ / s");
    }
}
