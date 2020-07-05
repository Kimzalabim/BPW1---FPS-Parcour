using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DoorController : MonoBehaviour
{
    [SerializeField] private float delay = 0;
    [SerializeField] private float openDuration = 1;
    [SerializeField] private Vector3 slideDirection;
    private Vector3 startPos;
    private Vector3 endPos;
    public AnimationCurve animationDoor;
    public void Start()
    {
        startPos = transform.position;
        endPos = startPos + slideDirection;
    }

    public void TESTDoor()
    {
        Debug.Log("Test: Door is opening");
    }

    public void DoorOnCountdown()
    {
        OpenDoor();
        //StartCoroutine(OpenDoorCorout(delay, openDuration));
        //CloseDoor();

        float i = 10;
        while (i > 1)
        {
            i -= Time.deltaTime;
            Debug.Log(i);
        }

        if (i < 1)
        {
            CloseDoor();
            //StartCoroutine(CloseDoorCorout(delay, openDuration));
        }
    }
    public void OpenDoor()
    {

        StartCoroutine(OpenDoorCorout(delay, openDuration));
        Debug.Log("Door is opening");

    }
    public void CloseDoor()
    {

        StartCoroutine(CloseDoorCorout(delay, openDuration));
        Debug.Log("Door is closing");

    }
    IEnumerator OpenDoorCorout(float delay, float openDuration)
    {
        yield return new WaitForSeconds(delay);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 1 / openDuration;
            transform.position = Vector3.Lerp(startPos, startPos + transform.TransformDirection(slideDirection), animationDoor.Evaluate(t));
            yield return null;
        }

    }
    IEnumerator CloseDoorCorout(float delay, float openDuration)
    {
        yield return new WaitForSeconds(delay);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 1 / openDuration;
            transform.position = Vector3.Lerp(endPos, startPos, animationDoor.Evaluate(t));
            //transform.position = Vector3.Lerp(endPos, endPos + transform.TransformDirection(-slideDirection), animationDoor.Evaluate(t));
            yield return null;
        }

    }
}
