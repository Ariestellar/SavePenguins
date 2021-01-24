using UnityEngine;
using PathCreation;
using System;

public class CharacterMovement : MonoBehaviour
{    
    
    [Header("Скорость передвижения по пути:")]
    [SerializeField] private float _speed;
    private Action _reachedEnd;
    private PathCreator _pathCreator;
    private float _distanceTravelled;

    public Action ReachedEnd { get => _reachedEnd; set => _reachedEnd = value; }

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
            _reachedEnd?.Invoke();
            Destroy(this.gameObject);
        }
    }

}
