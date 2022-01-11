using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private PlayerHealth _playerhealth;
    
    public void OnEnable()
    {
        _playerhealth.OnHealthChanged += Health; 
    }

    
    public void Health(int currentHealth,int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    public void OnDisable()
    {
        _playerhealth.OnHealthChanged -= Health;
    }
}
