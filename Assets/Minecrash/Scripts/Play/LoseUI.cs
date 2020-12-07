using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
public class LoseUI : MonoBehaviour
{
    public Text[] text;
    void Start()
    {
        Editor.down = true;
        text[0].text = MapLoader.score.ToString();
        if (MapLoader.Mode == 1)
            text[1].text = MapLoader.MapPlayer.HightScore.ToString();
        else
        {
            if (MapLoader.score > long.Parse(PlayerPrefs.GetString("ClassicHightScore", "0")))
                PlayerPrefs.SetString("ClassicHightScore", MapLoader.score.ToString());
            text[1].text = PlayerPrefs.GetString("ClassicHightScore", "0");
        }
    }
    void OnEnable()
    {
        if (FindObjectOfType<Sound>() != null)
        {
            FindObjectOfType<Sound>().fail();
        }
        Handheld.Vibrate();
        switch (Random.Range(0, 3))
        {
            case 0:
                Appodeal.show(Appodeal.INTERSTITIAL);
                break;
            case 1:
                Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
                break;
            case 2:
                Appodeal.show(Appodeal.REWARDED_VIDEO);
                break;
        }
    }
}