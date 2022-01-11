using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class adshow : MonoBehaviour
{
    private string gameId = "4311203";
    void Start()
    {
        Advertisement.Initialize(gameId);

    }

    public void ShowIntersitialAd()
    {
        
        Advertisement.Show("Interstitial_Android");
        


    }
}
