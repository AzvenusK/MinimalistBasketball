/*This the real AdManaging script which is responsible for both Banner Ads as well as Interstitial ads.*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdManager : MonoBehaviour {

	public static AdManager Instance { set; get; }      //This the instance declaration
    public string bannerId;                             //This is the app id for banner ads
    public string videoId;                              //This is the app id for interstitial ads

    private void Start()
    {
        Instance = this;                                //Here we have the a method which allows this object to never be destroyed 
        DontDestroyOnLoad(gameObject);                  //even if the scene are changed

        Admob.Instance().initAdmob(bannerId,videoId);   //Initialzing BAnnerId and VideoId from the admob
        Admob.Instance().setTesting(true);              //THIS NEEDS TO BE COMMENTED WHEN BEING PUBLISHED. THIS IS FOR TESTING.
        Admob.Instance().loadInterstitial();            //Loads the interstitial video in the RAM
    }

    public void ShowBanner()                            //This is the Banner ad function which needs to be called and is being called in the
    {                                                   //GameManager script in the LoadScene()
        
        Admob.Instance().showBannerRelative(AdSize.Banner,AdPosition.TOP_CENTER,0);
    }

    public void ShowVideo()                             //This is the Interstitial ad function which needs to be and is being called in the 
    {                                                   //whenever the panel is activated in the GameManager script and trajectoy script 
        if (Admob.Instance().isInterstitialReady())
        {
            
            Admob.Instance().showInterstitial();
        }
    }
}
