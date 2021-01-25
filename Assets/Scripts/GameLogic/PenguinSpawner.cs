using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSpawner : MonoBehaviour
{
    [Header("Ссылку на префаб пингвина")]
    [SerializeField] private GameObject _templatePenguin;
    [Header("Ссылку на путь пингвинов")]
    [SerializeField] private PathCreator _pathCreator;
    
    private PenguinСounter _penguinsCounter;

    public void Init(PenguinСounter penguinsCounter)
    {
        _penguinsCounter = penguinsCounter;
    }

    public void CreatePenguin()
    {
        var CurrentPenguin = Instantiate(_templatePenguin, _pathCreator.path.GetPoint(0), Quaternion.identity);
        CurrentPenguin.GetComponent<CharacterMovement>().Init(_pathCreator);
        CurrentPenguin.GetComponent<CharacterMovement>().ReachedEnd += _penguinsCounter.Append;
    }
}
