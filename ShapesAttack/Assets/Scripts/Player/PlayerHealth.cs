using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerHealth : MonoBehaviour
{
    public event Action OnDie;

    [SerializeField] private TakeItem _takeitem;

    [Header("HP")]
    public static int maxHealth;
    public int currentHealth;
    public event Action<int, int> OnHealthChanged;

    [Header("Реклама")]
    public GameObject adsbutton;
    public Adinit ad;
    public adshow show;

    [Space]
    public GameObject readypanel;
    private int tryCount;

    private void Awake()
    {
        tryCount = PlayerPrefs.GetInt("tryCount");
    }

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        readypanel.SetActive(false);
    }

    public void ApplyDamage(int damageEnemy)
    {
        if (!_takeitem.shield.activeInHierarchy)
        {
            currentHealth -= damageEnemy;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        else if (_takeitem.shield.activeInHierarchy)
        {
            _takeitem.shieldTimer.ReduceTime();
        }
    }

    public void Die()
    {
        OnDie?.Invoke();
        Count();
    }

    public void Health()
    {
        maxHealth += 5;
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);


    }

    public void Count()
    {
        tryCount++;
        PlayerPrefs.SetInt("tryCount", tryCount);
        if (tryCount % 3 == 0)
        {

            show.ShowIntersitialAd();
        }
    }

    public void AdsRew()
    {
        ad.ShowRewardAd();
        adsbutton.SetActive(false);
        readypanel.SetActive(true);


    }

    public void ResumeLife()
    {
        readypanel.SetActive(false);
        Time.timeScale = 1f;
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        _takeitem.shield.SetActive(true);
        _takeitem.shieldTimer.gameObject.SetActive(true);
        _takeitem.shieldTimer.isCooldown = true;

    }

}