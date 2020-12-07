using UnityEngine;
using AppodealAds.Unity.Api;
public class AdManager : MonoBehaviour
{
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
    }
    void Start()
    {
        Appodeal.setLogLevel(Appodeal.LogLevel.Verbose);
        Appodeal.initialize("c1a119049e99b7ebaae0601c243533ecda10ec0035cb945a", Appodeal.BANNER_BOTTOM | Appodeal.BANNER_RIGHT | Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.REWARDED_VIDEO, true);
        Appodeal.showTestScreen();
    }
}