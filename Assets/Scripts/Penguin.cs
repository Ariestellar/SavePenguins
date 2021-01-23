using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("уничтожение");
        Destroy(this.gameObject);
    }
}
