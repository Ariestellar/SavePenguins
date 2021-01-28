using UnityEngine;
/// <summary>
/// Класс выполняет функцию точки входа в игру и сервис локатора
/// </summary>
[RequireComponent(typeof(PenguinSpawner), typeof(ControllerTotalCounter))]
public class StartGame : MonoBehaviour
{
    [Header("Ссылку на UI общего счетчика")]   
    [SerializeField] private ViewTotalCounter _viewTotalCounter;
    
    [Header("Ссылку на UI панель улучшений")]
    [SerializeField] private ViewUpgradePanel _viewUpgradePanel;

    private PenguinSpawner _penguinSpawner;
    private PenguinСounter _penguinСounter;    
    private DataTotalCounter _dataTotalCounter;
    private DataImprovement[] _dataImprovements;
    private ControllerTotalCounter _controllerTotalCounter;


    private void Awake()
    {
        //Создаем необходимые компоненты для игры:
        _penguinСounter = new PenguinСounter();

        //Загружаем все необходимые ресурсы для игры:
        _dataImprovements = Resources.LoadAll<DataImprovement>("DataImprovement/");
        _dataTotalCounter = Resources.Load<DataTotalCounter>("TotalCounter");

        //Инициализируем все компоненты игры:
        _viewTotalCounter.Init(_dataTotalCounter);
        _controllerTotalCounter = GetComponent<ControllerTotalCounter>();
        _controllerTotalCounter.Init(_dataTotalCounter, _viewTotalCounter);

        _viewUpgradePanel.Init(_dataImprovements, _controllerTotalCounter);

        _penguinSpawner = GetComponent<PenguinSpawner>();
        _penguinSpawner.Init(_penguinСounter);
    }
}
