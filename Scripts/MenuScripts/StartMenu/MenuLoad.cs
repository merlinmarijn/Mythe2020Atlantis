using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoad : MonoBehaviour
{
    public SceneIndex index = SceneIndex.StartMenu;
    public void LoadScene()
    {
        GameManager.instance.LoadGame((int)index);
    }

}
