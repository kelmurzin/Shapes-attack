using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DigitalRuby.Pooling
{
    public class RestartGame : MonoBehaviour
    {
        
        public void RestartScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2, UnityEngine.SceneManagement.LoadSceneMode.Single);     
            SpawningPool.RemoveAllPrefabs();
            PooledObjectScript.instantiatedCount = PooledObjectScript.spawnCount = PooledObjectScript.returnToPoolCount = 0;
        }
              
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}