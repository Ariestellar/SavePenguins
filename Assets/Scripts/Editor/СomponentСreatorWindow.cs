using System.IO;
using UnityEditor;
using UnityEngine;

public class СomponentСreatorWindow : EditorWindow
{
	private string _name;	
	private float _priceUnlock;	
	private float _initialImprovementCostPercentage;	
	private float _priceIncreasePercentage;
	private float _amountIncrease;		
	private int _progressLimits;			
	private Sprite _sprite;

	[MenuItem("Window/СomponentСreatorWindow")]
	public static void ShowWindow()
	{
		GetWindow<СomponentСreatorWindow>("Создатель компонентов улучшений");
	}

	void OnGUI()
	{		
		GUILayout.Label("Окно для создания компонентов улучшения", EditorStyles.boldLabel);
		EditorGUILayout.Space();
		_name = EditorGUILayout.TextField("Имя", _name);
		_priceUnlock = EditorGUILayout.FloatField("Цена разблокировки", _priceUnlock);
		EditorGUILayout.Space();
		GUILayout.Label("Начальная стоимостью улучшений (в % от стоимости разблокировки)", EditorStyles.boldLabel);
		_initialImprovementCostPercentage = EditorGUILayout.FloatField(_initialImprovementCostPercentage, GUILayout.ExpandWidth(false));
		GUILayout.Label("На сколько увеличивается цена с каждым шагом (в % от текущей цены улучшения)", EditorStyles.boldLabel);
		_priceIncreasePercentage = EditorGUILayout.FloatField(_priceIncreasePercentage, GUILayout.ExpandWidth(false));
		GUILayout.Label("Лимит прогресса улучшения", EditorStyles.boldLabel);
		_progressLimits = EditorGUILayout.IntField(_progressLimits, GUILayout.ExpandWidth(false));		
		_sprite = (Sprite)EditorGUILayout.ObjectField("Спрайт", _sprite, typeof(Sprite), true );
		GUILayout.Label("Прибавка к доходу от этого умения в ед.времени (в % от текущего общего дохода)", EditorStyles.boldLabel);
		_amountIncrease = EditorGUILayout.FloatField(_amountIncrease, GUILayout.ExpandWidth(false));

		if (GUILayout.Button("Создать"))
		{
			CreateComponent();
		}
	}

	/// <summary>
	/// Создаем фаилы для хранения данных компонента "Улучшение" 
	/// </summary>
	private void CreateComponent()
	{
		DataImprovement data = ScriptableObject.CreateInstance<DataImprovement>();
		data.Init(_priceUnlock, _initialImprovementCostPercentage, _priceIncreasePercentage, _progressLimits, _sprite, _amountIncrease);		
		AssetDatabase.CreateAsset(data, "Assets/Resources/DataImprovement/" + _name + ".asset");					
		AssetDatabase.Refresh();

		ResetFieldParametrs();
	}

	/// <summary>
	/// Сбрасываем все параметры в полях 
	/// </summary>
	private void ResetFieldParametrs()
	{		
		_name = "";
		_priceUnlock = 0;
		_initialImprovementCostPercentage = 0;
		_priceIncreasePercentage = 0;
		_progressLimits = 0;
		_amountIncrease = 0;
		_sprite = null;
	}
}
