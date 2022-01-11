using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScroll : MonoBehaviour
{
    public static int Skill;

    [SerializeField] private PlayerHealth _playerhealth;

    public bool _Firerate { get => firerate < 10; }
    public bool _Speed { get => speed < 10; }
    public bool _BulletForece { get => bulletforce < 10; }
    public bool _Health { get => health < 10; }

   

    public Animator contentPanel;
    public GameObject MaskPanel;

    public Text skillscore;
    public int skillpoint;
    
    public Text lvlfirerate;
    public int firerate;

    public Text lvlBulletForce;
    public int bulletforce;

    public Text lvlSpeed;
    public int speed;

    public Text lvlHealth;
    public int health;

    public bool ActiveSkill; 

    private void Start()
    {
        Skill = 35;
        ActiveSkill = true;         
        MaskPanel.SetActive(true);
        //skillpoint = Mathf.Clamp(skillpoint, 0, 40);
    }

    public void Update()
    {
        
        skillscore.text = "Skills: " + skillpoint.ToString();
        if (ActiveSkill == true)
        {
            if (Skill >= 1)
            {
                skillpoint ++;
                Skill -= 1;
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
