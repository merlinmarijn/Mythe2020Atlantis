using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool hasKey=false;
    public void ChangeDoorState()
    {
        if (hasKey)
        {
            GetComponent<Animator>().SetTrigger("ChangeState");
        }
    }
}
