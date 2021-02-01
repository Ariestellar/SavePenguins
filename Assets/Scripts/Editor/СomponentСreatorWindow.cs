using System.IO;
using UnityEditor;
using UnityEngine;

public class СomponentСreatorWindow : EditorWindow
{
	private string _name;	
	private float _priceUnlock;	
	private float _initialImprovementCostPercentage;	
	private float _priceIncreasePercentage;
	//private int _currentProgress;	
	private int _progressLimits;	
	private float _amountIncrease;	
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
		_priceUnlock = EditorGUILayout.FloatField("Цена разблокировки", _priceUnlock);
		EditorGUILayout.Space();
		GUILayout.Label("Начальная стоимостью улучшений (в % от стоимости разблокировки)", EditorStyles.boldLabel);
		_initialImprovementCostPercentage = EditorGUILayout.FloatField(_initialImprovementCostPercentage, GUILayout.ExpandWidth(false));
		GUILayout.Label("На сколько увеличивается цена с каждым шагом (в % от текущей цены улучшения)", EditorStyles.boldLabel);
		_priceIncreasePercentage = EditorGUILayout.FloatField(_priceIncreasePercentage, GUILayout.ExpandWidth(false));
		GUILayout.Label("Лимит прогресса улучшения", EditorStyles.boldLabel);
		_progressLimits = EditorGUILayout.IntField(_progressLimits, GUILayout.ExpandWidth(false));		
		_sprite = (Sprite)EditorGUILayout.ObjectField("Спрайт", _sprite, typeof(Sprite), true );
				
		/*GUILayout.Label("Количество очков добавляемых к прибыли с каждым шагом", EditorStyles.boldLabel);
		_amountIncrease = EditorGUILayout.FloatField(_amountIncrease, GUILayout.ExpandWidth(false));*/

		if (GUILayout.Button("Создать"))
		{
			CreateComponent();
		}
		GUILayout.Label("Эту кнопку применять когда после игры необходимо", EditorStyles.miniLabel);		
		GUILayout.Label("скинуть все значения компонентов в дефолтные для", EditorStyles.miniLabel);		
		GUILayout.Label("начала игры заново", EditorStyles.miniLabel);
		EditorGUILayout.Space();
		if (GUILayout.Button("Сбросить все компоненты на дефолтное значение"))
		{
			DataReset();
		}
		EditorGUILayout.Space();
		GUILayout.Label("Пути сохранения фаилов: ", EditorStyles.miniLabel);
		GUILayout.Label("Assets/Scripts/GameLogic/Improvement/Data/Default/", EditorStyles.miniLabel);
		GUILayout.Label("Assets/Resources/DataImprovement/", EditorStyles.miniLabel);
		GUILayout.Label("Если каталоги будут измененны то получим ошибку", EditorStyles.miniLabel);
	}

	/// <summary>
	/// Создаем фаилы для хранения данных компонента "Улучшение" 
	/// </summary>
	private void CreateComponent()
	{
		DataImprovement data = ScriptableObject.CreateInstance<DataImprovement>();
		data.Init(_priceUnlock, _initialImprovementCostPercentage, _priceIncreasePercentage, _progressLimits, _amountIncrease = 0.1f, _sprite);
		//Создаем два варианта:
		//в папку "Default" - данные со значениями которые будут использоваться в начале игры
		//в папку "Resources" - данные для текущих значений которые будут использоваться в процессе игры
		//что бы можно было в любой момент сбросить до дефолтных значений текущие данные
		AssetDatabase.CreateAsset(data, "Assets/Scripts/GameLogic/Improvement/Data/Default/" + _name + ".asset");		
		AssetDatabase.CopyAsset("Assets/Scripts/GameLogic/Improvement/Data/Default/" + _name + ".asset", "Assets/Resources/DataImprovement/" + _name + ".asset");		
		AssetDatabase.Refresh();

		_name = "";
		_priceUnlock = 0;
		_initialImprovementCostPercentage = 0;
		_priceIncreasePercentage = 0;
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
