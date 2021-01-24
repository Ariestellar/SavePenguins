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
		GUILayout.Label("Эту кнопку применять когда после игры необходимо", EditorStyles.boldLabel);		
		GUILayout.Label("скинуть все значения компонентов в дефолтные для", EditorStyles.boldLabel);		
		GUILayout.Label("начала игры заново", EditorStyles.boldLabel);
		EditorGUILayout.Space();
		if (GUILayout.Button("Сбросить все компоненты на дефолтное значение"))
		{
			DataReset();
		}
		EditorGUILayout.Space();
		GUILayout.Label("Пути сохранения фаилов: ", EditorStyles.boldLabel);
		GUILayout.Label("Assets/Scripts/GameLogic/Improvement/Data/Default/", EditorStyles.boldLabel);
		GUILayout.Label("Assets/Resources/DataImprovement/", EditorStyles.boldLabel);
		GUILayout.Label("Если каталоги будут измененны то получим ошибку", EditorStyles.boldLabel);
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
		//в папку "Resources" - данные для текущих значений которые будут использоваться в процессе игры
		//что бы можно было в любой момент сбросить до дефолтных значений текущие данные
		AssetDatabase.CreateAsset(data, "Assets/Scripts/GameLogic/Improvement/Data/Default/" + _name + ".asset");		
		AssetDatabase.CopyAsset("Assets/Scripts/GameLogic/Improvement/Data/Default/" + _name + ".asset", "Assets/Resources/DataImprovement/" + _name + ".asset");		
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
		string[] nameAssets = Directory.GetFiles("Assets/Scripts/GameLogic/Improvement/Data/Default/", "*.asset");
		
        foreach (var item in nameAssets)
        {
			var nameItem = Path.GetFileName(item);
			AssetDatabase.CopyAsset("Assets/Scripts/GameLogic/Improvement/Data/Default/" + nameItem, "Assets/Resources/DataImprovement/" + nameItem);
		}      
	}
}
