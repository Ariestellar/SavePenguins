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
    [SerializeField] private Button _button;
    [SerializeField] private Text _buttonText;

    private DataImprovement _data;

    public void Init(DataImprovement data, UnityAction actionClickButton)
    {
        _data = data;
        
        _spriteImprovement.sprite = _data.Sprite;
        _nameText.text = _data.name;
        _progressCountText.text = _data.CurrentProgress + "/" + _data.ProgressLimits;
        _progressBarImage.fillAmount = (float)_data.CurrentProgress / _data.ProgressLimits;
        _buttonText.text = Convert.ToString(_data.Price);
        _button.onClick.AddListener(actionClickButton);
        _button.onClick.AddListener(ChangeViewButton);
        
    }

    private void Update()
    {
        if (_data != null)
        {
            //Каждый кадр сравниваем наличие общего счета с ценой улучшения что бы оперативно выключать интерактивность кнопки
            if (_data.PurchaseOpportunity == false || _data.OnLimitReached == true)//TODO: эту зависимость нужно разрешить
            {
                _button.interactable = false;
            }
            else
            {
                _button.interactable = true;
            }
        }        
    }

    /// <summary>
    /// Изменение отображения UI при клике 
    /// </summary>
    public void ChangeViewButton()
    {
        _progressBarImage.fillAmount = (float)_data.CurrentProgress / _data.ProgressLimits;
        _progressCountText.text = _data.CurrentProgress + "/" + _data.ProgressLimits;
        _buttonText.text = Convert.ToString(_data.Price);
    }
}
