using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class Menu : MonoBehaviour
{
    public Slider TimeBar;
    float value;
    public static bool isRun = false;
    public float time;
    public GameObject WinUI;
    public GameObject LoseUI;
    public GameObject PlayingUI;
    public static bool IsWin;
    public static bool IsLose;
    public static long scorebar = 0;
    bool onetime = false;
    void Start()
    {
        onetime = false;
        if (MapLoader.Mode == 1)
        {
            value = 1 / MapLoader.time;
        }
        else
        {
            TimeBar.value = 0;
            value = 1 / 5000f;
            scorebar = 0;
        }
        StartCoroutine(wait());
    }
    void Update()
    {
        if (isRun && MapLoader.Mode == 1)
            timeCountdown();
        else if (isRun && MapLoader.Mode == 0)
            ScoreInc();
    }
    void timeCountdown()
    {
        TimeBar.value = value * MapLoader.time;
        MapLoader.time -= Time.deltaTime;
        time = MapLoader.time;
        if (MapLoader.time <= 0 && !IsWin)
        {
            isRun = false;
            LoseUI.SetActive(true);
            IsLose = true;
        }
    }
    void ScoreInc()
    {
        if (scorebar <= 5000)
        {
            TimeBar.value = value * scorebar;
        }
        else if (!onetime)
        {
            onetime = true;
            StartCoroutine(ClassicUplevel());
        }
    }

    public void Win()
    {
        if (!IsLose)
        {
            if (FindObjectOfType<Sound>() != null)
            {
                FindObjectOfType<Sound>().pass();
            }
            isRun = false;
            WinUI.SetActive(true);
            IsWin = true;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        isRun = true;
    }

    IEnumerator ClassicUplevel()
    {
        JewelSpawn.spawnStart = false;
        Touch.supportTimeRp = 5f;
        //destroy all
        for (int x = 0; x < 7; x++)
            for (int y = 0; y < 9; y++)
                if (JewelSpawn.JewelList[x, y] != null)
                    JewelSpawn.JewelList[x, y].GetComponent<Jewel>().Destroying();
        yield return new WaitForSeconds(1.5f);
        Player p = new Player();
        p.HightScore = long.Parse(PlayerPrefs.GetString("ClassicHightScore", "0"));
        p.Level = MapLoader.MapPlayer.Level + 1;
        p.Name = "classic";
        p.Stars = 0;
        p.UnLocked = true;

        MapLoader.MapPlayer = p;
        MapLoader.Mode = 0;
        SceneManager.LoadScene("PlayScene");
    }

    public void timeinc(float _time)
    {
        if (!Menu.IsLose && !Menu.IsLose)
            StartCoroutine(inctimepersecond(_time));
    }
    IEnumerator inctimepersecond(float _time)
    {
        float tmptime = _time;
        float d = 0.4f;
        while (tmptime > 0)
        {
            yield return new WaitForSeconds(0.01f);
            if (MapLoader.time < MapLoader.TIMEPLAYER)
                MapLoader.time += d;
            tmptime -= d;
        }

    }

    public void scoreinc(long _score)
    {
        StartCoroutine(incscorepersecond(_score));
    }
    IEnumerator incscorepersecond(long _score)
    {
        long tmpscore = _score;
        int d = 1;
        while (tmpscore > 0)
        {
            yield return new WaitForSeconds(0.02f);
            if (scorebar <= 5000)
                scorebar += d;
            tmpscore -= d;
        }

    }

}
