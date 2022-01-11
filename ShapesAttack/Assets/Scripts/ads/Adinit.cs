using UnityEngine;
using UnityEngine.Advertisements;

public class Adinit : MonoBehaviour, IUnityAdsListener
{
    
    private string gameId = "4311203";

    private void Start()
    {
        Advertisement.Initialize(gameId, false);
        Advertisement.AddListener(this);
    }
    
    public void ShowRewardAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Rewarded_Android");
        }

    }
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (surfacingId == "Rewarded_Android")
            {
               

            }
        }
        else if (showResult == ShowResult.Skipped)
        {

        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {
       
    }
}