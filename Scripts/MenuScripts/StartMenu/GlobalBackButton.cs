using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalBackButton : MonoBehaviour
{
    public SceneIndex SceneToLoad = SceneIndex.StartMenu;
    public void GoBack()
    {
        GameManager.instance.LoadGame((int)SceneToLoad);
    }
}
