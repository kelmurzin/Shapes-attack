using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DigitalRuby.Pooling
{

    public class Mina : MonoBehaviour
    {
        
        public string Bomb1;        
        public Text minatext;
        public int minamanager;    
        
        public void Update()
        {
            minatext.text = minamanager.ToString();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Mina"))
            {
                Destroy(other.gameObject);
                minamanager += 1;
            }

        }

        public void SpawnMina()
        {
            if (minamanager >= 1)
            {
                string key = Bomb1;
                GameObject obj = SpawningPool.CreateFromCache(key);
                if (obj != null)
                {
                    obj.transform.position = transform.position;
                    obj.transform.rotation = transform.rotation;
                }
                minamanager -= 1;
            }

        }
        
    }
}