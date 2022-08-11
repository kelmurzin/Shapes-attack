using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTime : MonoBehaviour
{
    public float cooldown;

    [HideInInspector] public bool isCooldown;   
    [SerializeField] private TakeItem _takeitem;

    private Image speedImage;

    public void ResetTimer() => speedImage.fillAmount = 1;

    private void Start()
    {     
        speedImage = GetComponent<Image>();        
        isCooldown = true;       
    }
    
    private void Update()
    {
        if (isCooldown)
        {
            
            speedImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (speedImage.fillAmount <= 0)
            {
                speedImage.fillAmount = 1;
                isCooldown = false;
                PlayerMove.moveSpeed -= 4f;
                _takeitem.speedt.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

}