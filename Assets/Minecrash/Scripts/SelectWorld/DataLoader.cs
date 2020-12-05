using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.UI.Extensions;
public class DataLoader : MonoBehaviour
{
    public static List<Player> DataPlayer;
    public Button unlockAllButton;
    void Start()
    {
        DataPlayer = new List<Player>();
        //PlayerPrefs.DeleteAll ();
        if (bool.Parse(PlayerPrefs.GetString("FIRSTTIME", "True")))
            DataDefaultLoader();

        SaveDataToList();

        unlockAllButton.onClick.AddListener(UnlockAllLevels);
    }

    void setWorldUnlock()
    {
        if (DataPlayer[0].UnLocked)
        {
            this.transform.GetChild(0).GetComponent<Button>().enabled = true;
            this.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Text>().text = UnlockCount(DataPlayer, 0).ToString() + "/99";
            this.GetComponentInParent<HorizontalScrollSnap>().GoToScreen(0);
        }
        else
        {
            this.transform.GetChild(0).GetComponent<Button>().enabled = false;
            this.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

        if (DataPlayer[99].UnLocked)
        {
            this.transform.GetChild(1).GetComponent<Button>().enabled = true;
            this.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>().text = UnlockCount(DataPlayer, 1).ToString() + "/99";
            this.GetComponentInParent<HorizontalScrollSnap>().GoToScreen(1);
        }
        else
        {
            this.transform.GetChild(1).GetComponent<Button>().enabled = false;
            this.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

        if (DataPlayer[198].UnLocked)
        {
            this.transform.GetChild(2).GetComponent<Button>().enabled = true;
            this.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Text>().text = UnlockCount(DataPlayer, 2).ToString() + "/99";
            this.GetComponentInParent<HorizontalScrollSnap>().GoToScreen(2);
        }
        else
        {
            this.transform.GetChild(2).GetComponent<Button>().enabled = false;
            this.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
    }

    int UnlockCount(List<Player> l, int worldindex)
    {
        int tmp = 0;
        for (int i = worldindex * 99; i < (worldindex + 1) * 99; i++)
        {
            if (l[i].UnLocked) tmp++;
        }
        return tmp;
    }

    void SaveDataToList()
    {
        List<Player> tmp = new List<Player>();
        PlayerPrefsSerializer mpp = new PlayerPrefsSerializer();
        tmp = mpp.LoadPref();
        for (int i = 0; i < 297; i++)
        {
            DataPlayer.Add(tmp[i]);
        }
        setWorldUnlock();
    }

    void DataDefaultLoader()
    {
        string AssetFileName = "WorldData";
        string AssetFilePath;
#if UNITY_IPHONE
        AssetFilePath = @"Assets/Minecrash/Resources/" + AssetFileName + ".txt";
#else
        AssetFilePath = @"Assets/Minecrash/Resources/" + AssetFileName + ".xml";
#endif

        string XmlString = "";
#if UNITY_EDITOR
        XmlString = UnityEditor.AssetDatabase.LoadAssetAtPath<TextAsset>(AssetFilePath).ToString();
#else
		XmlString = ((TextAsset)Resources.Load (AssetFileName, typeof(TextAsset))).ToString ();
#endif
        PlayerPrefs.SetString("DATA", XmlString);
        PlayerPrefs.SetString("FIRSTTIME", "False");
    }

    void UnlockAllLevels()
    {
        for (int i = 0; i < DataPlayer.Count; i++)
        {
            DataPlayer[i].UnLocked = true;
        }
        if (FindObjectOfType<Sound>() != null)
            FindObjectOfType<Sound>().pass();

        SaveDataToList();
    }
}
