using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStartMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex != (int)SceneIndex.StartMenu || SceneManager.GetActiveScene().buildIndex != (int)SceneIndex.Game)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene((int)SceneIndex.Manager);
            }
        }
    }
}
