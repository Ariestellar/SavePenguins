using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CharacterMovement : MonoBehaviour
{
    [Header("Сюда установить ссылку на путь:")]
    [SerializeField] private PathCreator _pathCreator;
    [Header("Скорость передвижения по пути:")]
    [SerializeField] private float _speed;

    [SerializeField] private float _distanceTravelled;

    public void Init(PathCreator pathCreator)
    {
        _pathCreator = pathCreator;              
    }    

    private void Update()
    {        
        _distanceTravelled += _speed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);

        if (_pathCreator.path.GetClosestTimeOnPath(transform.position) == 1)
        {
            Destroy(this.gameObject);
        }
    }

}
