using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loadsc : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image circle;
    public int SceneID;
    private void Start()
    {
        StartCoroutine(LoadSceneCor());
    }
    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(0.5f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneID);
        while(!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            circle.fillAmount = progress;
            yield return 0;
        }
    }
}
