using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public static float fireRate;
    public static float bulletForce;

    [SerializeField] private ControlType controlType;
    [SerializeField]
    private enum ControlType
    {
        PC, Android
    }

    [Space]
    [SerializeField] private Joystick firejoystick;
    [SerializeField] private Rigidbody2D rb;
    [Space]
    [SerializeField] private AudioSource fire;
    [SerializeField] private Text Level;
    [SerializeField] private int levelscore;
    [Space]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gun2;
    [SerializeField] private GameObject gun3;
    
    [Space]
    [SerializeField] private int upgradeState = 0;
    [SerializeField] private List<Transform> firePoint;
    [SerializeField] private Transform point;
    
    [Header("Виды улучшений")]
    [SerializeField] private List<Transform> One;
    [Space]
    [SerializeField] private List<Transform> Two;
    [Space]
    [SerializeField] private List<Transform> Three;
    [Space]
    [SerializeField] private List<Transform> Four;
    [Space]
    [SerializeField] private List<Transform> Five;
    [Space]
    [SerializeField] private List<Transform> Six;

    private float curTimeout;

    private  void Start()
    {
        fireRate = 0.8f;
        bulletForce = 12f;
        firePoint = new List<Transform>();
        firePoint.Add(point);   
    }

    private void Update()
    {
        
        if ( Mathf.Abs(firejoystick.Horizontal) > 0.3f || Mathf.Abs(firejoystick.Vertical) > 0.3f)
        {
            float angle = Mathf.Atan2(firejoystick.Vertical, firejoystick.Horizontal) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }

        if (curTimeout <= 0)
        {
            switch (controlType)
            {
                case ControlType.PC:
                    if (Input.GetMouseButton(0))
                        Shoot();
                    break;

                case ControlType.Android:
                    if (firejoystick.Horizontal != 0 || firejoystick.Vertical != 0)
                        Shoot();
                    break;
            }
        }
        else
            curTimeout -= Time.deltaTime;
        
    }

    public void Shoot()
    {
        
        foreach (Transform turret in firePoint)
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Player Bullet");
            if (bullet != null)
            {
                bullet.transform.position = turret.position;
                bullet.transform.rotation = turret.rotation;
                bullet.SetActive(true);
            }

            curTimeout = fireRate;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(turret.up * bulletForce, ForceMode2D.Impulse);
            
        }

        fire.Play();
    }
        
    public void UpgradeWeapons()
    {
        switch (upgradeState)
        {
            case 0:
                levelscore ++;
                foreach (Transform turret in One)
                    firePoint.Add(turret);                
                break;

            case 1:
                foreach (Transform turret in Two)
                    firePoint.Add(turret);                
                levelscore ++;
                break;

            case 2:
                foreach (Transform turret in Three)
                {
                    gun2.SetActive(true);
                    firePoint.Add(turret);
                }
                levelscore ++;
                break;

            case 3:
                foreach (Transform turret in Four)
                    firePoint.Add(turret);                
                levelscore ++;
                break;

            case 4:
                levelscore ++;
                break;
            case 5:
                levelscore ++;
                break;

            case 6:
                foreach (Transform turret in Five)
                {
                    firePoint.Add(turret);
                    gun3.SetActive(true);
                }
                levelscore ++;
                break;

            case 7:
                levelscore ++;
                break;

            case 8:
                levelscore ++;
                foreach (Transform turret in Six)
                    firePoint.Add(turret);                
                break;
        }
        upgradeState++;
        Level.text = "Lvl: " + levelscore.ToString();
    }    
}   