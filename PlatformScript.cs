using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("joe");
        //if (other.gameObject == Player)
        //{
            Player.transform.parent = transform;
       
        //}
    }

    private void OnTriggerExit(Collider other)
    {
                    Debug.Log("joddddde");

        //if(other.gameObject == Player)
        //{
            Player.transform.parent = null;

        //}
    }
}
