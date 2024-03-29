﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Pooling
{

    public class Bullet : MonoBehaviour
    {
        public string explosionbul;
        
        Rigidbody2D rb;
        
        [SerializeField] private static int damage ;
        public float force;
               
        private void Start()
        {
            damage = 50;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {                                  
            Vector3 directon = new Vector3(0, force, 0);            
            rb.AddForce(directon, ForceMode2D.Impulse);
        }
        
        private void OnBecameInvisible()=>              
            gameObject.SetActive(false);
        
                
        private void OnTriggerEnter2D(Collider2D other)
        {
            IDamageble idamage = other.GetComponent<IDamageble>();
            if (idamage != null)            
            {
                string key = explosionbul;
                GameObject obj = SpawningPool.CreateFromCache(key);
                if (obj != null)
                {
                    obj.transform.position = transform.position;
                    obj.transform.rotation = transform.rotation;
                }

                idamage.TakeDamage(damage);                
                gameObject.SetActive(false);
            }                        
        }        
    }
}