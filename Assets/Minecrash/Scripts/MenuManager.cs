using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
public class MenuManager : MonoBehaviour
{
    public Toggle soundToggle;
    public Toggle musicToggle;
    public GameObject PauseUI;
    public static bool isPause = false;
    public string previousScene;
    void Start()
    {
        if (soundToggle != null)
        {
            if (PlayerPrefs.GetString("sound", "ON").CompareTo("ON") == 0)
            {
                soundToggle.isOn = true;
                if (FindObjectOfType<Sound>() != null)
                {
                    FindObjectOfType<Sound>().SoundON();
                }
            }
            else
            {
                soundToggle.isOn = false;
                if (FindObjectOfType<Sound>() != null)
                {
                    FindObjectOfType<Sound>().SoundOFF();
                }
            }
        }

        if (musicToggle != null)
        {
            if (PlayerPrefs.GetString("music", "ON").CompareTo("ON") == 0)
            {
                musicToggle.isOn = true;
                FindObjectOfType<Music>().MusicON();
            }
            else
            {
                musicToggle.isOn = false;
                FindObjectOfType<Music>().MusicOFF();
            }
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 1 && currentSceneIndex < 4)
        {
            RemoveAds();
            CreateAds();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClickSound();

            if (PauseUI != null)
                Pause();
            else if (previousScene == "")
                Application.Quit();
            else
            {
                SceneManager.LoadScene(previousScene);
                RemoveAds();
            }
        }
    }
    public void ClickSound()
    {
        if (FindObjectOfType<Sound>() != null)
        {
            FindObjectOfType<Sound>().click();
        }
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ArcadeMode()
    {
        Player p = new Player();
        p.HightScore = long.Parse(PlayerPrefs.GetString("ClassicHightScore", "0"));
        p.Level = 1;
        p.Name = "classic";
        p.Stars = 0;
        p.UnLocked = true;

        MapLoader.MapPlayer = p;
        MapLoader.Mode = 0;
        MapLoader.score = 0;
    }
    public void ToggleSound(bool sound)
    {
        if (sound)
        {
            PlayerPrefs.SetString("sound", "ON");
            if (FindObjectOfType<Sound>() != null)
            {
                FindObjectOfType<Sound>().SoundON();
            }
        }
        else
        {
            PlayerPrefs.SetString("sound", "OFF");
            if (FindObjectOfType<Sound>() != null)
            {
                FindObjectOfType<Sound>().SoundOFF();
            }
        }
    }
    public void ToggleMusic(bool music)
    {
        if (music)
        {
            PlayerPrefs.SetString("music", "ON");
            FindObjectOfType<Music>().MusicON();
        }
        else
        {
            PlayerPrefs.SetString("music", "OFF");
            FindObjectOfType<Music>().MusicOFF();
        }
    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public void SelectWorld(int worldNumber)
    {
        WorldData.world = worldNumber;
    }
    public void Pause()
    {
        if (PauseUI != null)
        {
            Editor.down = true;
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
            Menu.isRun = false;
        }
    }
    public void Resume()
    {
        Editor.down = false;
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        isPause = false;
        Menu.isRun = true;
    }
    public void Exit()
    {
        if (MapLoader.Mode == 1 && MapLoader.MapPlayer != null)
        {
            WorldData.world = (MapLoader.MapPlayer.Level - 1) / 99;
            SceneManager.LoadScene("MapSelect");
        }
        else
            SceneManager.LoadScene("HomeScene");
    }
    public void Restart()
    {
        if (MapLoader.Mode != 1)
            ArcadeMode();
    }
    public void CreateAds()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        Appodeal.show(Appodeal.BANNER_BOTTOM);
#endif
    }
    public void RemoveAds()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        if (previousScene == "HomeScene" || MapLoader.Mode != 1)
            Appodeal.hide(Appodeal.BANNER);
#endif
    }
    void OnApplicationFocus(bool hasFocus)
    {
#if UNITY_ANDROID || UNITY_IPHONE
        if (hasFocus)
        {
            Appodeal.onResume(Appodeal.BANNER);
        }
#endif
    }
}
