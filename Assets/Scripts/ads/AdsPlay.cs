using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPlay : MonoBehaviour
{
    [SerializeField] private GameObject adsbutton;
    [SerializeField] private Adinit ad;
    [SerializeField] private adshow show;
    [SerializeField] private PlayerHealth _playerhealth;

    [Space]
    public GameObject readypanel;
    private int tryCount;

    private void Awake()
    {
        tryCount = PlayerPrefs.GetInt("tryCount");
    }

    private void Start()
    {
        readypanel.SetActive(false);
    }

    private void OnEnable()
    {
        _playerhealth.OnDie += Count;
    }


    public void Count()
    {
        tryCount++;
        PlayerPrefs.SetInt("tryCount", tryCount);
        if (tryCount % 3 == 0)
        {
            show.ShowIntersitialAd();
        }
    }

    public void AdsRew()
    {
        ad.ShowRewardAd();
        adsbutton.SetActive(false);
        readypanel.SetActive(true);
    }

    public void ClosePanel()
    {
        readypanel.SetActive(false);
    }
    private void OnDisable()
    {
        _playerhealth.OnDie -= Count;
        
    }
}
