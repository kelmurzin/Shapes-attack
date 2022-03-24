using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PlayerHealth _playerhealth;
    
    private void OnEnable()
    {
        _playerhealth.OnHealthChanged += Health; 
    }
   
    public void Health(int currentHealth,int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    private void OnDisable()
    {
        _playerhealth.OnHealthChanged -= Health;
    }
}