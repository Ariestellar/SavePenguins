using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Класс отвечает за отображение элементов улучшения
/// Находится на префабе элемента улучшения
/// </summary>
public class ViewUpgrade : MonoBehaviour
{     
    [Header("Ссылки на элементы уже установленны в префабе:")]
    [SerializeField] private Image _spriteImprovement;
    [SerializeField] private Image _progressBarImage;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _progressCountText;
    [SerializeField] private Button _buttonUpgrade;
    [SerializeField] private Text _buttonUpgradeText;
    [SerializeField] private GameObject _panelUnlock;    
    [SerializeField] private GameObject _panelUpgrade;

    private DataImprovement _data;
    private Button _buttonUnlock;

    public void Init(DataImprovement data, UnityAction unlockUpgrade, UnityAction actionClickButton)
    {
        _data = data;
        
        _spriteImprovement.sprite = _data.Sprite;
        _nameText.text = _data.name;
        _progressCountText.text = _data.CurrentProgress + "/" + _data.ProgressLimits;
        _progressBarImage.fillAmount = (float)_data.CurrentProgress / _data.ProgressLimits;        
        _buttonUpgradeText.text = Convert.ToString(_data.PriceUpgrade);
        if (_data.IsUnlock == true)
        {
            ShowPanelUpgrade();
        }
        else
        {
            _panelUnlock.GetComponentInChildren<Text>().text = "Разблокировать за " + _data.PriceUnlock + " $";
            _buttonUnlock = _panelUnlock.GetComponentInChildren<Button>();
            _buttonUnlock.onClick.AddListener(ShowPanelUpgrade);
            _buttonUnlock.onClick.AddListener(unlockUpgrade);   
        }
        _buttonUpgrade.onClick.AddListener(actionClickButton);
        _buttonUpgrade.onClick.AddListener(ChangeViewButton);
    }

    private void Update()
    {
        if (_data != null)
        {
            //Каждый кадр сравниваем наличие общего счета с ценой улучшения что бы оперативно выключать интерактивность кнопки
            if (_data.IsPurchaseOpportunityUpgrade == false || _data.OnLimitReached == true)//TODO: эту зависимость нужно разрешить
            {
                _buttonUpgrade.interactable = false;
                
            }
            else
            {
                _buttonUpgrade.interactable = true;
                
            }

            if (_panelUnlock.activeSelf == true)
            {
                if (_data.IsPurchaseOpportunityUnlock == false)
                {
                    _buttonUnlock.interactable = false;
                }
                else
                {
                    _buttonUnlock.interactable = true;
                }                
            }            
        }        
    }

    /// <summary>
    /// Показать панель улучшения, и скрыть панель разблокировки
    /// </summary>
    private void ShowPanelUpgrade()
    {        
        _panelUpgrade.SetActive(true);
        _panelUnlock.SetActive(false);
    }

    /// <summary>
    /// Изменение отображения UI при клике 
    /// </summary>
    public void ChangeViewButton()
    {
        _progressBarImage.fillAmount = (float)_data.CurrentProgress / _data.ProgressLimits;
        _progressCountText.text = _data.CurrentProgress + "/" + _data.ProgressLimits;
        _buttonUpgradeText.text = Convert.ToString(_data.PriceUpgrade);
    }
}
