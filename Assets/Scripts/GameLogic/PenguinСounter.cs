using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinСounter : MonoBehaviour
{
    [SerializeField] int _totalCountPenguins;

    public void Append()
    {
        _totalCountPenguins += 1;
    }
}
