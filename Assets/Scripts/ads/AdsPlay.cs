using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsPlay : MonoBehaviour
{
    [SerializeField] private GameObject adsbutton;
    [SerializeField] private Adinit ad;
    [SerializeField] private adshow show;
    [SerializeField] private PlayerHealth _playerhealth;
    [SerializeField] private PanelLose panelLose;
    [SerializeField] private YandexSDK yandexSDK;
    [Space]
    public GameObject readypanel;
    private int tryCount;
    private YandexSDK sdk;

    private void Awake()
    {
        tryCount = PlayerPrefs.GetInt("tryCount");
    }

    private void Start()
    {
        Debug.Log("aaa");
        sdk = YandexSDK.instance;
        sdk.onRewardedAdReward += AdsRew;
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
            //show.ShowIntersitialAd();
        }
    }

    public void AdsRew(string placement)
    {
        if (placement == "life")
        {
            //ad.ShowRewardAd();
            
        }
    }
    public void ADSHOW()
    {
        // adsbutton.SetActive(false);
        //readypanel.SetActive(true);
        // StartCoroutine(PanelClose());
        //Invoke("PanelClose", 1f);
        yandexSDK.ShowRewarded("life");
        PanelClose();
    }

    private void PanelClose()
    {
        adsbutton.SetActive(false);      
        panelLose.Close();       
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
