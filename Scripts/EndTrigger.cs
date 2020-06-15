using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Interactible))]
public class EndTrigger : MonoBehaviour
{
    int i = 0;

    public void EndGame()
    {
        if (i == 2)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameManager.instance.LoadGame((int)SceneIndex.Credits);
            //Application.Quit();
            //Debug.Log("COMPLETED GAME");
        }
    }
    //gets called when 1 of the neccesary items gets placed wich is needed to end the game
    public void InputItem()
    {
        i++;
    }
}
