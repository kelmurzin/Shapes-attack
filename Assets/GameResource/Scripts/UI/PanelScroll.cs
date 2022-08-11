using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScroll : MonoBehaviour
{
    public static int Skill;
    public Animator contentPanel;
    public GameObject MaskPanel;
    public Text skillscore;
    public Text lvlfirerate;
    public Text lvlBulletForce;
    public Text lvlSpeed;
    public Text lvlHealth;

    [SerializeField] private PlayerHealth _playerhealth;

    private bool _Firerate { get => firerate < 10; }
    private bool _Speed { get => speed < 10; }
    private bool _BulletForece { get => bulletforce < 10; }
    private bool _Health { get => health < 10; }
    private int skillpoint;
    private int firerate;
    private int bulletforce;
    private int speed;
    private int health;
    private bool ActiveSkill = true;

    private void Start()
    {
        Skill = 20;                     
        MaskPanel.SetActive(true);   
    }

    private void Update()
    {
        
        skillscore.text = "Skills: " + skillpoint.ToString();
        if (ActiveSkill)
        {
            if (Skill >= 20)
            {
                skillpoint ++;
                Skill -= 20;
                contentPanel.SetBool("IsHidden", true);
            }
            if (skillpoint <= 0)
            {
                contentPanel.SetBool("IsHidden", false);
            }
        }

        if (!_BulletForece && !_Firerate && !_Speed && !_Health)
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
        if (_Speed)
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
        if (_Firerate)

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
        if (_BulletForece)
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
        if (_Health)
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
