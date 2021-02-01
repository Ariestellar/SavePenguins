using UnityEditor;
using UnityEngine;

public class GameDifficultyCurveEditor : EditorWindow
{	
	private AnimationCurve _upgradeCost = new AnimationCurve();
	private AnimationCurve _penguinProfit = new AnimationCurve();

	[MenuItem("Window/SettingsDifficultyCurve")]	

	public static void ShowWindow()
	{
		GetWindow<GameDifficultyCurveEditor>("Настройки кривых сложности");
	}

	void OnGUI()
	{
		GUILayout.Label("Окно для настройки кривых сложности", EditorStyles.boldLabel);
		EditorGUILayout.Space();
		GUILayout.Label("Кривая прибыли от пингвинов", EditorStyles.label);
		EditorGUILayout.CurveField(_penguinProfit, GUILayout.Width(95), GUILayout.Height(100), GUILayout.ExpandWidth(true));
		EditorGUILayout.Space();
		GUILayout.Label("Кривая стоимости улучшений", EditorStyles.label);
		EditorGUILayout.CurveField(_upgradeCost, GUILayout.Width(95), GUILayout.Height(100), GUILayout.ExpandWidth(true));
	}
}
