using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IronSourceSampleAds : MonoBehaviour
{
    
    [SerializeField] private string APP_KEY; 
    [SerializeField] private Text RewardedScoreText;
    private readonly string TAG = "IronSource-Ads";
    private int RewardedScore = 0;
    void Start()
    {

        IronSource.Agent.validateIntegration();
        //Sdk init
        IronSource.Agent.init(APP_KEY);

        RewardedScoreText.text = $"SCORE : {RewardedScore}";
        
    }

    void OnEnable(){
        //Init events
        IronSourceEvents.onSdkInitializationCompletedEvent += onSdkInitializationCompletedEvent;

        //Interstitial Events
        IronSourceEvents.onInterstitialAdReadyEvent += InterstitialAdReadyEvent;
        IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialAdLoadFailedEvent;        
        IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent; 
        IronSourceEvents.onInterstitialAdShowFailedEvent += InterstitialAdShowFailedEvent; 
        IronSourceEvents.onInterstitialAdClickedEvent += InterstitialAdClickedEvent;
        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;

        //Add AdInfo Interstitial Events
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;

        //RewardedAd Events
        IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
        IronSourceEvents.onRewardedVideoAdClickedEvent += RewardedVideoAdClickedEvent;
        IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent; 
        IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
        IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
        IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
        IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent; 
        IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent;

        //Add AdInfo Rewarded Video Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadInterstitialButtonClicked(){
        Debug.Log($"{TAG} LoadInterstitialButtonClicked");
        IronSource.Agent.loadInterstitial();
    }

    public void ShowInterstitialButtonClicked(){
        Debug.Log($"{TAG} ShowInterstitialButtonClicked");
        if(IronSource.Agent.isInterstitialReady()){
            IronSource.Agent.showInterstitial();
        }
        else{
            Debug.Log($"{TAG} Ironsource agent is not ready");
        }
    }

    public void ShowRewardedAdButtonClicked(){
        Debug.Log($"{TAG} ShowRewardedAdButtonClicked");
        if(IronSource.Agent.isRewardedVideoAvailable()){
            IronSource.Agent.showRewardedVideo();
        }
        else{
            Debug.Log($"{TAG} Ironsource agent is rewarded video not available");
        }
    }

    #region Events
    private void onSdkInitializationCompletedEvent()
    {
        Debug.Log($"{TAG} onSdkInitializationCompletedEvent");
    }

    // Invoked when the initialization process has failed.
    // @param description - string - contains information about the failure.
    void InterstitialAdLoadFailedEvent (IronSourceError error) {
        Debug.Log($"{TAG} I got InterstitialAdLoadFailedEvent, code {error.getCode()}, description : {error.getDescription()}");
    }
    // Invoked when the ad fails to show.
    // @param description - string - contains information about the failure.
    void InterstitialAdShowFailedEvent(IronSourceError error) {
        Debug.Log($"{TAG} I got InterstitialAdShowFailedEvent, code {error.getCode()}, description : {error.getDescription()}");
    }
    // Invoked when end user clicked on the interstitial ad
    void InterstitialAdClickedEvent () {
        Debug.Log($"{TAG} I got InterstitialAdClickedEvent");
    }
    // Invoked when the interstitial ad closed and the user goes back to the application screen.
    void InterstitialAdClosedEvent () {
        Debug.Log($"{TAG} I got InterstitialAdClosedEvent");
    }
    // Invoked when the Interstitial is Ready to shown after load function is called
    void InterstitialAdReadyEvent() {
        Debug.Log($"{TAG} I got InterstitialAdReadyEvent");
    }
    // Invoked when the Interstitial Ad Unit has opened
    void InterstitialAdOpenedEvent() {
        Debug.Log($"{TAG} I got InterstitialAdOpenedEvent");
    }
    // Invoked right before the Interstitial screen is about to open.
    // NOTE - This event is available only for some of the networks. 
    // You should not treat this event as an interstitial impression, but rather use InterstitialAdOpenedEvent
    void InterstitialAdShowSucceededEvent() {
        Debug.Log($"{TAG} I got InterstitialAdShowSucceededEvent");
    }

    /************* Interstitial AdInfo Delegates *************/
    // Invoked when the interstitial ad was loaded succesfully.
    void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo) {
        Debug.Log($"{TAG} I got InterstitialOnAdReadyEvent with AdInfo {adInfo.ToString()}");
    }
    // Invoked when the initialization process has failed.
    void InterstitialOnAdLoadFailed(IronSourceError ironSourceError) {
        Debug.Log($"{TAG} I got InterstitialOnAdLoadFailed with error {ironSourceError.ToString()}");
    }
    // Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 
    void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo) {
        Debug.Log($"{TAG} I got InterstitialOnAdOpenedEvent with AdInfo {adInfo.ToString()}");
    }
    // Invoked when end user clicked on the interstitial ad
    void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo) {
        Debug.Log($"{TAG} I got InterstitialOnAdClickedEvent with AdInfo {adInfo.ToString()}");
    }
    // Invoked when the ad failed to show.
    void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo) {
        Debug.Log($"{TAG} I got InterstitialOnAdLoadFailed with error {ironSourceError.ToString()} and AdInfo {adInfo.ToString()}");
    }
    // Invoked when the interstitial ad closed and the user went back to the application screen.
    void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo) {
        Debug.Log($"{TAG} I got InterstitialOnAdClosedEvent with AdInfo {adInfo.ToString()}");
    }
    // Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.
    // This callback is not supported by all networks, and we recommend using it only if  
    // it's supported by all networks you included in your build. 
    void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo) {
        Debug.Log($"{TAG} I got InterstitialOnAdShowSucceededEvent with AdInfo {adInfo.ToString()}");
    }


    //Invoked when the RewardedVideo ad view has opened.
    //Your Activity will lose focus. Please avoid performing heavy 
    //tasks till the video ad will be closed.
    void RewardedVideoAdOpenedEvent() {
        Debug.Log($"{TAG} I got RewardedVideoAdOpenedEvent");
    }  
    //Invoked when the RewardedVideo ad view is about to be closed.
    //Your activity will now regain its focus.
    void RewardedVideoAdClosedEvent() {
        Debug.Log($"{TAG} I got RewardedVideoAdClosedEvent");
    }
    //Invoked when there is a change in the ad availability status.
    //@param - available - value will change to true when rewarded videos are available. 
    //You can then show the video by calling showRewardedVideo().
    //Value will change to false when no videos are available.
    void RewardedVideoAvailabilityChangedEvent(bool available) {
        //Change the in-app 'Traffic Driver' state according to availability.
        bool rewardedVideoAvailability = available;
        Debug.Log($"{TAG} I got RewardedVideoAvailabilityChangedEvent, value = {rewardedVideoAvailability}");
    }

    //Invoked when the user completed the video and should be rewarded. 
    //If using server-to-server callbacks you may ignore this events and wait for 
    // the callback from the  ironSource server.
    //@param - placement - placement object which contains the reward data
    void RewardedVideoAdRewardedEvent(IronSourcePlacement placement) {
        Debug.Log($"{TAG} I got RewardedVideoAdRewardedEvent, amount = {placement.getRewardAmount()} name = {placement.getRewardName()}");
        RewardedScore += placement.getRewardAmount();
        RewardedScoreText.text = $"SCORE : {RewardedScore}";
    }
    //Invoked when the Rewarded Video failed to show
    //@param description - string - contains information about the failure.
    void RewardedVideoAdShowFailedEvent (IronSourceError error){
        Debug.Log($"{TAG} I got RewardedVideoAdShowFailedEvent, code = {error.getCode()}, description : {error.getDescription()}");
    }

    // ----------------------------------------------------------------------------------------
    // Note: the events below are not available for all supported rewarded video ad networks. 
    // Check which events are available per ad network you choose to include in your build. 
    // We recommend only using events which register to ALL ad networks you include in your build. 
    // ----------------------------------------------------------------------------------------

    //Invoked when the video ad starts playing. 
    void RewardedVideoAdStartedEvent() { 
        Debug.Log($"{TAG} I got RewardedVideoAdStartedEvent");
    } 
    //Invoked when the video ad finishes playing. 
    void RewardedVideoAdEndedEvent() { 
        Debug.Log($"{TAG} I got RewardedVideoAdEndedEvent");
    }
    
    //Invoked when the video ad is clicked. 
    void RewardedVideoAdClickedEvent(IronSourcePlacement placement) { 
        Debug.Log($"{TAG} I got RewardedVideoAdClickedEvent, name = {placement.getRewardName()}");
    }


    
    /************* RewardedVideo AdInfo Delegates *************/
    // Indicates that there’s an available ad.
    // The adInfo object includes information about the ad that was loaded successfully
    // This replaces the RewardedVideoAvailabilityChangedEvent(true) event
    void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo) {
        Debug.Log($"{TAG} I got RewardedVideoOnAdAvailable with adInfo {adInfo.ToString()}");
    }
    // Indicates that no ads are available to be displayed
    // This replaces the RewardedVideoAvailabilityChangedEvent(false) event
    void RewardedVideoOnAdUnavailable() {
        Debug.Log($"{TAG} I got RewardedVideoOnAdUnavailable");
    }
    // The Rewarded Video ad view has opened. Your activity will loose focus.
    void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo){
        Debug.Log($"{TAG} I got RewardedVideoOnAdAvailable with adInfo {adInfo.ToString()}");
    }
    // The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
    void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo){
        Debug.Log($"{TAG} I got RewardedVideoOnAdAvailable with adInfo {adInfo.ToString()}");
    }
    // The user completed to watch the video, and should be rewarded.
    // The placement parameter will include the reward data.
    // When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
    void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
        Debug.Log($"{TAG} I got RewardedVideoOnAdRewardedEvent with placement {placement.getPlacementName()} and adInfo {adInfo.ToString()} ");
    }
    // The rewarded video ad was failed to show.
    void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo){
        Debug.Log($"{TAG} I got RewardedVideoOnAdClickedEvent with error {error.ToString()} and adInfo {adInfo.ToString()} ");

    }
    // Invoked when the video ad was clicked.
    // This callback is not supported by all networks, and we recommend using it only if
    // it’s supported by all networks you included in your build.
    void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo){
        Debug.Log($"{TAG} I got RewardedVideoOnAdClickedEvent with placement {placement.getPlacementName()} and adInfo {adInfo.ToString()} ");
    }




    #endregion
}
