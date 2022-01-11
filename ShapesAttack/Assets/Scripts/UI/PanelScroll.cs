using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScroll : MonoBehaviour
{
    public static int Skill;

    [SerializeField] private PlayerHealth _playerhealth;

    private bool _Firerate { get => firerate < 10; }
    private bool _Speed { get => speed < 10; }
    private bool _BulletForece { get => bulletforce < 10; }
    private bool _Health { get => health < 10; }
   
    public Animator contentPanel;
    public GameObject MaskPanel;

    public Text skillscore;
    private int skillpoint;
    
    public Text lvlfirerate;
    private int firerate;

    public Text lvlBulletForce;
    private int bulletforce;

    public Text lvlSpeed;
    private int speed;

    public Text lvlHealth;
    private int health;

    private bool ActiveSkill; 

    private void Start()
    {
        Skill = 100;
        
        ActiveSkill = true;         
        MaskPanel.SetActive(true);
        
    }

    public void Update()
    {
        
        skillscore.text = "Skills: " + skillpoint.ToString();
        if (ActiveSkill == true)
        {
            if (Skill >= 10)
            {
                skillpoint ++;
                Skill -= 10;
                contentPanel.SetBool("IsHidden", true);
            }
            if (skillpoint <= 0)
            {
                contentPanel.SetBool("IsHidden", false);
            }
        }

        if (_BulletForece == false && _Firerate == false && _Speed == false && _Health == false)
        {
            Close();
        }
    }

    public void Close()
    {
        ActiveSkill = false;
        contentPanel.SetBool("IsHidden", false);
        MaskPanel.SetActive(false);
    }

    public void Speed()
    {
        if (_Speed == true)
        {
            if (skillpoint >= 1)
            {
                PlayerMove.moveSpeed += 0.3f;
                skillpoint --;
                speed ++;
                lvlSpeed.text = "LVL: " + speed.ToString("0");
            }
        }
    }

    public void FireRate()
    {
        if (_Firerate == true)

        {
            if (skillpoint >= 1)
            {
                Shooting.fireRate -= 0.05f;
                skillpoint --;
                firerate ++;
                lvlfirerate.text = "LVL: " + firerate.ToString("0");
            }

        }

    }

    public void BulletForece()
    {
        if (_BulletForece == true)
        {
            if (skillpoint >= 1)
            {
                Shooting.bulletForce += 0.8f;
                skillpoint --;
                bulletforce ++;
                lvlBulletForce.text = "LVL: " + bulletforce.ToString("0");
            }
        }

    }

    public void Health()
    {
        if (_Health == true)
        {
            if (skillpoint >= 1)
            {
                _playerhealth.Health();
                skillpoint --;
                health ++;
                lvlHealth.text = "LVL: " + health.ToString("0");
            }
        }

    }

}
