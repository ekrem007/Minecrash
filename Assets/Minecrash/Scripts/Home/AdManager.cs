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
        Appodeal.disableNetwork(AppodealNetworks.A4G);
        Appodeal.disableNetwork(AppodealNetworks.AMAZON_ADS);
        Appodeal.disableNetwork(AppodealNetworks.IRONSOURCE);
        Appodeal.disableNetwork(AppodealNetworks.MY_TARGET);
        Appodeal.disableNetwork(AppodealNetworks.STARTAPP);
        Appodeal.disableNetwork(AppodealNetworks.SMAATO);
        Appodeal.initialize("c1a119049e99b7ebaae0601c243533ecda10ec0035cb945a", Appodeal.BANNER_BOTTOM | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.INTERSTITIAL, false);
    }
}