using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public ControlType controlType;

    public enum ControlType
    {
        PC, Android
    }

    public Joystick firejoystick;
    public Rigidbody2D rb;

    [SerializeField] private AudioSource fire;
    public Text Level;
    public int levelscore;

    public GameObject bulletPrefab;
    public GameObject gun2;
    public GameObject gun3;
    
    public static float fireRate ;
    private float curTimeout;

    [Space]    
    public int upgradeState = 0;
    public List<Transform> firePoint;
    public Transform point;
    public static float bulletForce ;

    [Header("Виды улучшений")]
    public List<Transform> One;
    [Space]
    public List<Transform> Two;
    [Space]
    public List<Transform> Three;
    [Space]
    public List<Transform> Four;
    [Space]
    public List<Transform> Five;
    [Space]
    public List<Transform> Six;

    

    
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
            if (controlType == ControlType.PC)
            {
                if (Input.GetMouseButton(0))
                {
                    Shoot();

                }
            }
            if (controlType == ControlType.Android)
            {
                if (firejoystick.Horizontal != 0 || firejoystick.Vertical != 0)
                {
                    Shoot();
                }
            }
        }
        else
        {
            curTimeout -= Time.deltaTime;
        }
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
        
        if (upgradeState == 0)
        {
            levelscore = 2;
            foreach (Transform turret in One)
            {
                firePoint.Add(turret);
                
            }
        }
        else if (upgradeState == 1)
        {
            foreach (Transform turret in Two)
            {
                firePoint.Add(turret);
            }
            levelscore = 3;

        }
        else if (upgradeState == 2)
        {
            foreach (Transform turret in Three)
            {
                gun2.SetActive(true);
                firePoint.Add(turret);
            }
            levelscore = 4;
        }
        else if (upgradeState == 3)
        {
            foreach (Transform turret in Four)
            {
                firePoint.Add(turret);
            }

            levelscore = 5;            
        }
        else if (upgradeState == 4)
        {            
            levelscore = 6;
        }
        else if (upgradeState == 5)
        {
            levelscore = 7;            
        }
        else if (upgradeState == 6)
        {
            foreach (Transform turret in Five)
            {
                firePoint.Add(turret);
                gun3.SetActive(true);
            }
            levelscore = 8;
        }
        else if (upgradeState == 7)
        {
            levelscore = 9;           
        }
        
        else if (upgradeState == 8)
        {
            levelscore = 10;
            foreach (Transform turret in Six)
            {
                firePoint.Add(turret);
                
            }

        }
       
        upgradeState++;
        Level.text = "Lvl: " + levelscore.ToString();
    }
    
}   