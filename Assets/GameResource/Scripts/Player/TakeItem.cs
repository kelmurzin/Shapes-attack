using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    [SerializeField] private PlayerMove _player;

    [Header("Скорость")]
    public GameObject speedt;
    public SpeedTime speedtime;

    [Header("Щит")]
    public GameObject shield;
    public Shield shieldTimer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bulletpoint"))      
        {
            _shooting.UpgradeWeapons();
            Destroy(collision.gameObject);
        }

       else if (collision.CompareTag("BoostSpeed"))
        {
            if (!speedt.activeInHierarchy)
            {
                speedtime.gameObject.SetActive(true);
                speedtime.isCooldown = true;
                speedt.SetActive(true);
                Destroy(collision.gameObject);
                PlayerMove.moveSpeed += 4f;
            }
            else
            {
                speedtime.ResetTimer();
                Destroy(collision.gameObject);
            }
        }

        else if (collision.CompareTag("Shield"))
        {
            if (!shield.activeInHierarchy)
            {
                shield.SetActive(true);
                shieldTimer.gameObject.SetActive(true);
                shieldTimer.isCooldown = true;
                Destroy(collision.gameObject);
            }
            else
            {
                shieldTimer.ResetTimer();
                Destroy(collision.gameObject);
            }
        }

    }
}