using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float cooldown;

    [HideInInspector] public bool isCooldown;    
    [SerializeField]private TakeItem _takeitem;

    private Image shieldImage;

    public void ResetTimer() => shieldImage.fillAmount = 1;

    public void ReduceTime() => shieldImage.fillAmount -= 2 / 5f;

    private void Start()
    {
        shieldImage = GetComponent<Image>();
        isCooldown = true;
    }
       
    private void Update()
    {
        if(isCooldown)
        {
            shieldImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if(shieldImage.fillAmount <=0)
            {
                shieldImage.fillAmount = 1;
                isCooldown = false;
                _takeitem.shield.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
 
}