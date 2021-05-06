using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADManager : MonoBehaviour
{
    public static ADManager instance;
    private string playstoreId = "";
    private string appstoreId = "";

    private string videoad = "video";
    private string rewardedad = "rewardedVideo";
    private string bannerad = "bannerAd";

    //set false for app store
    public bool isPlayStore = true;
    //set false when launching game
    public bool isTestAd = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        InitializeMonetization();
    }

    private void InitializeMonetization()
    {
        if (isPlayStore)
        {
            Advertisement.Initialize(playstoreId,isTestAd);
            return;
        }
        Advertisement.Initialize(appstoreId,isTestAd);
    }

    public void ShowInterstitialAd(Action<ShowResult> callback)
    {
        if (Advertisement.IsReady(videoad))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callback;
            Advertisement.Show(videoad,so);
        }
        else
        {
            //Not Ready Spawn Ad Later... Go Online
        }
    }
    public void ShowRewardedVideoAd(Action<ShowResult> callback)
    {
        if (Advertisement.IsReady(rewardedad))
        {
            ShowOptions so = new ShowOptions();
            so.resultCallback = callback;
            Advertisement.Show(rewardedad,so);
        }
        else
        {
            //Not Ready Spawn Ad Later... Go Online
        }
    }

    public void ShowBannerAd(bool showAd, bool destroy = false)
    {
        if (Advertisement.IsReady(bannerad))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerad);
            if(!showAd)
                Advertisement.Banner.Hide(destroy);
        }
        else
        {
            //Not Ready Spawn Ad Later... Go Online
        }
    }    
}
