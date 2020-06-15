using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent eventtrigger;
    public void TriggerNow()
    {
        eventtrigger.Invoke();
    }

}
