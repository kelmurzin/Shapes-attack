using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Pooling
{    
    public class ButtonRestartGame : ButtonAction
    {
        public override void ButtonClick()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2, UnityEngine.SceneManagement.LoadSceneMode.Single);
            SpawningPool.RemoveAllPrefabs();
            PooledObjectScript.instantiatedCount = PooledObjectScript.spawnCount = PooledObjectScript.returnToPoolCount = 0;
        }
    }
}