using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _templatePenguin;
    [SerializeField] private PathCreator _pathCreator;

    public void CreatePenguin()
    {
        var CurrentPenguin = Instantiate(_templatePenguin);
        CurrentPenguin.GetComponent<CharacterMovement>().Init(_pathCreator);
    }
}
