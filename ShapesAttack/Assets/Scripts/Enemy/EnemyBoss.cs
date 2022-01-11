using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Pooling
{


    public class EnemyBoss : EnemyBase, IDamageble
    {
        public string enemypref;        
        public GameObject lvlup;              
        
        [Space]
        public Transform enemypoint;
        public Transform healthBarTransform;

        protected override void Start()
        {
            base.Start();
            
            StartCoroutine(Spawnenemy());
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerHealth>())
            {
                collision.gameObject.GetComponent<PlayerHealth>().Die();
                Destroy(gameObject);
            }
        }
        public void TakeDamage(int damage)
        {
            health.SetActive(true);
            
            Healthbar healthBar =
                healthBarTransform.gameObject.GetComponent<Healthbar>();
            healthBar.currentHealth -= Mathf.Max(damage, 0);
            
            if (healthBar.currentHealth <= 0)
            
            {
                
                Destroy(gameObject);
                Score.instance.AddPoint(pointEnemy);
                Instantiate(lvlup, transform.position, transform.rotation);
            }
        }
        
        IEnumerator Spawnenemy()
        {
            while (true)
            {
                string key = enemypref;
                GameObject obj = SpawningPool.CreateFromCache(key);
                if (obj != null)
                {
                    obj.transform.position = enemypoint.position;
                    obj.transform.rotation = enemypoint.rotation;
                }
                yield return new WaitForSeconds(4f);
            }
           
        }


    }
}