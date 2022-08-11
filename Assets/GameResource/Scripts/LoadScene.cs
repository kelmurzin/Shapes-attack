using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    AsyncOperation asyncOperation;
    [SerializeField] private Image circle;
    [SerializeField] private int SceneID;

    private void Start() => StartCoroutine(LoadSceneCor());
   
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