using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateWheel : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    private bool coroutineAllowed;
    private int numberShown;

    private void Start(){
        coroutineAllowed = true;
        numberShown = 5;
    }

    public void Rotate(){
        if(coroutineAllowed){
            StartCoroutine("rotateWheel");
        }
    }

    private IEnumerator rotateWheel(){
        coroutineAllowed = false;

      
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y  + 40f, 0f);
        yield return new WaitForSeconds(0.01f);
    

        coroutineAllowed = true;

        numberShown += 1;

        if(numberShown > 9){
            numberShown = 0;
        }

        Rotated(name, numberShown);
    }
}
