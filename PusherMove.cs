using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherMove : MonoBehaviour
{
    [SerializeField] private float delay = 0;
    [SerializeField] private float openDuration = 1;
    [SerializeField] private Vector3 slideDirection;
    private Vector3 startPos;
    private Vector3 endPos;
    public AnimationCurve animationDoor;
    private bool pusherMoveCycleComplete = true;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + slideDirection;
    }

  
    void Update()
    {
        MovePusher();
    }

    public void MovePusher()
    {
        if (pusherMoveCycleComplete)
        {
            StartCoroutine(MovingPusherCorout(delay, openDuration));
            pusherMoveCycleComplete = false;
        }
    }

    IEnumerator MovingPusherCorout(float delay, float openDuration)
    {

        yield return new WaitForSeconds(delay);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 1 / openDuration;
            transform.position = Vector3.Lerp(startPos, startPos + transform.TransformDirection(slideDirection), animationDoor.Evaluate(t));
            yield return null;
        }

        yield return new WaitForSeconds(delay);
        float i = 0;
        while (i < 1)
        {
            i += Time.deltaTime * 1 / openDuration;
            transform.position = Vector3.Lerp(endPos, startPos, animationDoor.Evaluate(i));
            //transform.position = Vector3.Lerp(endPos, endPos + transform.TransformDirection(-slideDirection), animationDoor.Evaluate(t));
            yield return null;
        }

        pusherMoveCycleComplete = true;
        //Debug.Log("floep");

    }
}
