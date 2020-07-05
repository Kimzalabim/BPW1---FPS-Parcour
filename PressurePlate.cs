using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent onActivated;
    //[SerializeField] private bool isOpened = false;

    void OnTriggerEnter(Collider other)
    {
       
            //isOpened = true;
            onActivated?.Invoke();
        
    }
}
