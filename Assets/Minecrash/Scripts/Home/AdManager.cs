using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
public class AdManager : MonoBehaviour, IPermissionGrantedListener
{
    public void writeExternalStorageResponse(int result)
    {
        if (result == 0)
        {
            Debug.Log("WRITE_EXTERNAL_STORAGE permission granted");
        }
        else
        {
            Debug.Log("WRITE_EXTERNAL_STORAGE permission grant refused");
        }
    }
    public void accessCoarseLocationResponse(int result)
    {
        if (result == 0)
        {
            Debug.Log("ACCESS_COARSE_LOCATION permission granted");
        }
        else
        {
            Debug.Log("ACCESS_COARSE_LOCATION permission grant refused");
        }
    }
    void Awake()
    {
        if (FindObjectsOfType<AdManager>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
#if UNITY_ANDROID
        Appodeal.requestAndroidMPermissions(this);
#endif
    }
    void Start()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        Appodeal.initialize("c1a119049e99b7ebaae0601c243533ecda10ec0035cb945a", Appodeal.BANNER_BOTTOM | Appodeal.BANNER_RIGHT | Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.REWARDED_VIDEO, true);
        if (Debug.isDebugBuild)
        {
            Appodeal.setLogLevel(Appodeal.LogLevel.Verbose);
            Appodeal.showTestScreen();
        }
#endif
    }
}