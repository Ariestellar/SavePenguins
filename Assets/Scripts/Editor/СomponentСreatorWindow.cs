using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class СomponentСreatorWindow : EditorWindow
{
	private string _name;	
	private int _price;	
	private int _priceIncrease;
	//private int _currentProgress;	
	private int _progressLimits;	
	private int _amountIncrease;	
	private Sprite _sprite;
	//private bool _onLimitReached;

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
		_price = EditorGUILayout.IntField("Цена", _price);
		EditorGUILayout.Space();
		GUILayout.Label("Во сколько раз увеличивается цена с каждым шагом", EditorStyles.boldLabel);
		_priceIncrease = EditorGUILayout.IntField( _priceIncrease, GUILayout.ExpandWidth(false));
		GUILayout.Label("Лимит прогресса улучшения", EditorStyles.boldLabel);
		_progressLimits = EditorGUILayout.IntField(_progressLimits, GUILayout.ExpandWidth(false));
		GUILayout.Label("Количество очков добавляемых к прибыли с каждым шагом", EditorStyles.boldLabel);
		_amountIncrease = EditorGUILayout.IntField(_amountIncrease, GUILayout.ExpandWidth(false));			
		_sprite = (Sprite)EditorGUILayout.ObjectField("Спрайт", _sprite, typeof(Sprite), true );

		if (GUILayout.Button("Создать"))
		{
			CreateComponent();
		}
		GUILayout.Label("Эту кнопку применять когда после игры необходимо скинуть все значения компонентов в дефолтные для начала игры заново", EditorStyles.boldLabel);
		EditorGUILayout.Space();
		if (GUILayout.Button("Сбросить все компоненты на дефолтное значение"))
		{
			DataReset();
		}
	}

	/// <summary>
	/// Создаем фаилы для хранения данных компонента "Улучшение" 
	/// </summary>
	private void CreateComponent()
	{
		DataImprovement data = ScriptableObject.CreateInstance<DataImprovement>();
		data.Init(_price, _priceIncrease, _progressLimits, _amountIncrease, _sprite);
		//Создаем два варианта:
		//в папку "Default" - данные со значениями которые будут использоваться в начале игры
		//в папку "Current" - данные для текущих значений которые будут использоваться в процессе игры
		//что бы можно было в любой момент сбросить до дефолтных значений текущие данные
		AssetDatabase.CreateAsset(data, "Assets/Scripts/Improvement/Data/Default/" + _name + ".asset");		
		AssetDatabase.CopyAsset("Assets/Scripts/Improvement/Data/Default/" + _name + ".asset", "Assets/Resources/" + _name + ".asset");		
		AssetDatabase.Refresh();

		_name = "";
		_price = 0;
		_priceIncrease = 0;
		_progressLimits = 0;
		_amountIncrease = 0;
		_sprite = null;
	}

	private void DataReset()
	{
		string[] nameAssets = Directory.GetFiles("Assets/Scripts/Improvement/Data/Default/" , "*.asset");
		
        foreach (var item in nameAssets)
        {
			var nameItem = Path.GetFileName(item);
			AssetDatabase.CopyAsset("Assets/Scripts/Improvement/Data/Default/" + nameItem, "Assets/Resources/" + nameItem);
		}      
	}
}
