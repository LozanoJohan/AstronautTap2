using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
{

    // #if UNITY_IOS
    // private string gameId = "5136399";
    // #elif UNITY_ANDROID
    private string gameId = "5136398";
    // #endif

    Button myButton;
    public string myPlacementId;
    public GameObject canvas;
    public GameObject canvas1;
    public GameObject camara;
    private GameObject player;

    void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, false);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (placementId == "Rewarded_Android")
            {
                PowerUpsManager.I.InvincibilityPower.Activate();

                player.transform.position = new Vector2(0f, camara.transform.position.y - 2);
                player.SetActive(true);
                player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                canvas.GetComponent<Animator>().SetTrigger("Close");
                canvas1.SetActive(true);
                AudioManager.I.MuteMusic();
            }
            else
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars", 0) + 75);

        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("“The ad did not finish due to an error.”");
        }
        Advertisement.RemoveListener(this);
        myButton.interactable = false;
        myButton.onClick.RemoveListener(ShowRewardedVideo);
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    public void ShowInter()
    {
        if ((int)Random.Range(1, 4) == 3)
            Advertisement.Show("Interstitial_Android");
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
