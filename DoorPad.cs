﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPad : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool isOpened = false;
    void OnTriggerEnter(Collider other)
    {
        if (!isOpened)
        {
            isOpened = true;
            door.transform.position += new Vector3(0, 4, 0);
        }
    }
            
}
