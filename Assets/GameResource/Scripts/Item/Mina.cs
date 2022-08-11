using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DigitalRuby.Pooling
{

    public class Mina : MonoBehaviour
    {
        public event Action<int> onValueChange = delegate { };

        [SerializeField] private string Bomb;        
        [SerializeField] private int minamanager;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Mina"))
            {
                Destroy(other.gameObject);
                minamanager++;
                onValueChange(minamanager);
            }

        }

        public void SpawnMina()
        {
            if (minamanager >= 1)
            {
                string key = Bomb;
                GameObject obj = SpawningPool.CreateFromCache(key);
                if (obj != null)
                {
                    obj.transform.position = transform.position;
                    obj.transform.rotation = transform.rotation;
                }
                minamanager--;
                onValueChange(minamanager);
            }

        }
        
    }
}