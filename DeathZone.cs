using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DeathZone : MonoBehaviour
{
    public UnityEvent onActivated;
    void OnTriggerEnter(Collider other)
    {
        onActivated?.Invoke();
    }

}
