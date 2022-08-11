using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public event Action OnDie = delegate { } ;

    [SerializeField] private TakeItem _takeitem;

    [Header("HP")]
    public static int maxHealth;
    public int currentHealth;
    public event Action<int, int> onHealthChanged = delegate { } ;
   
    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        if(onHealthChanged !=null)
        onHealthChanged(currentHealth, maxHealth);
        
    }

    public void ApplyDamage(int damageEnemy)
    {
        if (!_takeitem.shield.activeInHierarchy)
        {
            currentHealth -= damageEnemy;
            if (onHealthChanged != null)
                onHealthChanged(currentHealth, maxHealth);
            if (currentHealth <= 0)
                Die();           
        }

        else if (_takeitem.shield.activeInHierarchy)
            _takeitem.shieldTimer.ReduceTime();        
    }

    public void Die()=>
            OnDie?.Invoke();
            
    public void Health()
    {
        maxHealth += 5;
        currentHealth = maxHealth;
        if (onHealthChanged != null)
            onHealthChanged(currentHealth, maxHealth);
    }
  
    public void ResumeLife()
    {        
        Time.timeScale = 1f;
        currentHealth = maxHealth;       
        _takeitem.shield.SetActive(true);
        _takeitem.shieldTimer.gameObject.SetActive(true);
        _takeitem.shieldTimer.isCooldown = true;
        if (onHealthChanged != null)
            onHealthChanged(currentHealth, maxHealth);
    }

}