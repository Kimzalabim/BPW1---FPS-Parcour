using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SingleMove : MonoBehaviour
{
    [SerializeField] private float delayMove1 = 0;
    [SerializeField] private float delayMove2 = 0;
    [SerializeField] private float openDuration = 1;
    [SerializeField] private Vector3 slideDirection;
    private Vector3 startPos;
    private Vector3 endPos;
    public AnimationCurve animationDoor;
  

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + slideDirection;
    }

    public void SingleOpenAndClose()
    {
        StartCoroutine(SingleMoveCorout(delayMove1, openDuration, delayMove2));
    }

    IEnumerator SingleMoveCorout(float delayMove1, float openDuration, float delayMove2)
    {
        yield return new WaitForSeconds(delayMove1);
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 1 / openDuration;
            transform.position = Vector3.Lerp(startPos, startPos + transform.TransformDirection(slideDirection), animationDoor.Evaluate(t));
            yield return null;
        }

        yield return new WaitForSeconds(delayMove2);
        float i = 0;
        while (i < 1)
        {
            i += Time.deltaTime * 1 / openDuration;
            transform.position = Vector3.Lerp(endPos, startPos, animationDoor.Evaluate(i));
            //transform.position = Vector3.Lerp(endPos, endPos + transform.TransformDirection(-slideDirection), animationDoor.Evaluate(t));
            yield return null;
        }

    }


}

