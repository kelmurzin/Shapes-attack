using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRuby.Pooling
{
    public class Enemy : EnemyBase, IDamageble
    {
        public DropItem _dropItem;        
        public string explosion;

        [SerializeField] private int damageEnemy;
       
        public Transform healthBarTransform;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerHealth>())
            {
                collision.gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageEnemy);               
                Score.instance.Combo();
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
                Die();            
        }
        
        private void Die()
        {
            string key = explosion;
            GameObject obj = SpawningPool.CreateFromCache(key);
            if (obj != null)
            {
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
            }
            
            Destroy(gameObject);                        
            Score.instance.AddPoint(pointEnemy);            
            _dropItem.generateLoot();
                        
        }       
    }
}