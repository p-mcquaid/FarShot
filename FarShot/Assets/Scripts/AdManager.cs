using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Advertisements;
//using GoogleMobileAds.Api;




public class AdManager : MonoBehaviour {

    public static AdManager adManager;

    private string store_ID = "2943923";

    private string video_ad = "video";
    private string rewardedVideo_ad = "rewardedVideo";
    private string banner_ad = "banner";
    private float timer;


    //private BannerView bannerView;
    void Awake()
    {
        if (adManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            adManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Advertisement.Initialize(store_ID, false);
        //String appID = "ca-app-pub-1332738477775689~8702985637";
        //MobileAds.Initialize(appID);
        //this.ShowBanner();
    }
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShowAd();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ShowRewardedAd();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            ShowBanner();
        }
    }

    public void ShowAd()
    {
        if (Advertisement.IsReady(video_ad) && timer <= 0)
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(video_ad, options);
            Analytics.CustomEvent("Served Ad");

            timer = 150f;
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewardedVideo_ad))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(rewardedVideo_ad, options);
            Analytics.CustomEvent("Served Rewarded Ad");

        }
    }

    public void ShowBanner()
    {
        if (Advertisement.IsReady(banner_ad))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show(banner_ad, options);
            Analytics.CustomEvent("Served Banner Ad");

        }
        //string adUnitID = "ca-app-pub-1332738477775689/2673242839";
        //string adUnitID = "ca-app-pub-3940256099942544/6300978111";
        //bannerView = new BannerView(adUnitID, AdSize.Banner, AdPosition.Bottom);
        //AdRequest request = new AdRequest.Builder().Build();
        //bannerView.LoadAd(request);
    }

    public void bannerClicked()
    {
        Analytics.CustomEvent("Banner Ad Clicked");

    }

    public void IAP_Request()
    {
        Analytics.CustomEvent("Player requested to purchase skin");

    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("Ad was not shown");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad was skipped");
                //Analytics.CustomEvent("Ad Shown Skipped");
                break;
            case ShowResult.Finished:
                Debug.Log("Ad was shown successfully");
                //Analytics.CustomEvent("Ad Shown Successfully");
                //Code for rewards
                break;
            default:
                break;
        }
    }

}
