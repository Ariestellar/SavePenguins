using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTotalCounter : MonoBehaviour
{
    [SerializeField] private DataTotalCounter _data;
    [SerializeField] private Text _textTotalScore;
    [SerializeField] private Text _textProfit;

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
