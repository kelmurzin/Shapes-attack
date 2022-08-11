using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Pooling
{
    public class Bomb : MonoBehaviour
    {
        public AudioSource bang;        
        public GameObject effect;

        public int damage;
        public string bomb;

        private void Start() => bang.Play();
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            IDamageble idamage = other.GetComponent<IDamageble>();

            if (idamage != null)
            {
                
                string key = bomb;
                GameObject obj = SpawningPool.CreateFromCache(key);

                if (obj != null)
                {
                    obj.transform.position = transform.position;
                    obj.transform.rotation = transform.rotation;
                }

                idamage.TakeDamage(damage);
                Destroy(gameObject, 0.4f);
            }

        }
    
    }
}