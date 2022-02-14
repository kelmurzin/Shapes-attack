using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace DigitalRuby.Pooling 
{
    [System.Serializable]
    public class WaveAction
    {
        public string name;
        public float delay;        
        public int spawnCount;
        public string message;
        public Transform[] spawn;
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public List<WaveAction> actions;
    }

    public class WaveGenerator : MonoBehaviour
    {
        
        public float difficultyFactor = 0.7f;
        public List<Wave> waves;
        private Wave m_CurrentWave;
        public Wave CurrentWave { get { return m_CurrentWave; } }
        private float m_DelayFactor = 1.0f;

        IEnumerator SpawnLoop()
        {
            m_DelayFactor = 1.0f;
            while (true)
            {
                foreach (Wave W in waves)
                {
                    m_CurrentWave = W;
                    foreach (WaveAction A in W.actions)
                    {
                        if (A.delay > 0)
                            yield return new WaitForSeconds(A.delay * m_DelayFactor);
                        if (A.message != "")
                        {
                            //Debug.Log("11");
                        }
                        if ( A.spawnCount > 0)
                        {
                            for (int i = 0; i < A.spawnCount; i++)
                            {
                                Transform randomspawn = A.spawn[Random.Range(0, A.spawn.Length)];                             
                                yield return new WaitForSeconds(0.3f);
                                string key = A.name;
                                GameObject obj = SpawningPool.CreateFromCache(key);
                                if(obj !=null)
                                {
                                    obj.transform.position = randomspawn.position;
                                    obj.transform.rotation = randomspawn.rotation;
                                }                                                               
                            }
                        }

                    }
                    yield return null;  
                }
                m_DelayFactor *= difficultyFactor;
                yield return null;  
            }

        }

        void Start()
        {
            StartCoroutine(SpawnLoop());
        }
    }
}