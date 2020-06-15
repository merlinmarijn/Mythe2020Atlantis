using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject LoadingScreen;
    public ProgressBar bar;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndex.StartMenu, LoadSceneMode.Additive);
    }
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadGame(int index = 2)
    {
        LoadingScreen.gameObject.SetActive(true);
        Scene[] Active = SceneManager.GetAllScenes();
        foreach (Scene item in Active)
        {
            if (item.buildIndex != (int)SceneIndex.Manager)
            {
                SceneManager.UnloadSceneAsync(item);
            }
        }
        //scenesLoading.Add(SceneManager.UnloadSceneAsync((int)SceneIndex.StartMenu));
        scenesLoading.Add(SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        for(int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;
                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }
                totalSceneProgress = (totalSceneProgress / scenesLoading.Count) * 100f;
                bar.current = Mathf.RoundToInt(totalSceneProgress);
                yield return null;
            }
        }
        LoadingScreen.gameObject.SetActive(false);
    }
}
