using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public bool hasShader;
    public string name;
    public InteractType interact_type = InteractType.Inspect;
    TextMeshProUGUI T;

    private void Start()
    {
        T = GameObject.FindGameObjectWithTag("InteractibleUI").GetComponent<TextMeshProUGUI>();
    }

    //Standard Button "E"
    public void InvokeAction1()
    {
        OnActionEvent1.Invoke();
    }
    //Standard Mouse Left
    public void InvokeAction2()
    {
        OnActionEvent2.Invoke();
    }
    //Standard Mouse Right
    public void InvokeAction3()
    {
        OnActionEvent3.Invoke();
    }

    public void EnableLookAt()
    {
        T.enabled = true;
        T.text="Press E to " + interact_type + " " + name;
    }

    public void DisableLookAt()
    {
        T.enabled = false;
    }

    [Serializable]
    public class myEvents : UnityEvent { }
    [SerializeField]
    [Header("Standard Button 'E'")]
    private myEvents ActionEvent1 = new myEvents();
    public myEvents OnActionEvent1 { get { return ActionEvent1; } set { ActionEvent1 = value; } }

    [SerializeField]
    [Header("Standard Mouse 1")]
    private myEvents ActionEvent2 = new myEvents();
    public myEvents OnActionEvent2 { get { return ActionEvent2; } set { ActionEvent2 = value; } }

    [SerializeField]
    [Header("Standard Mouse 2")]
    private myEvents ActionEvent3 = new myEvents();
    public myEvents OnActionEvent3 { get { return ActionEvent3; } set { ActionEvent3 = value; } }

    public enum InteractType
    {
        Inspect,
        Move,
        Cheat,
        PickUp,
        Place,
        End_Game,
        Open
    }
}


