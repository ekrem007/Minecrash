using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinUI : MonoBehaviour
{
    public Text[] text;
    public GameObject[] stars;
    string _name;
    long score = 0;
    // Use this for initialization
    void Start()
    {
        Editor.down = true;
        score = MapLoader.score + (int)MapLoader.time * 500;
        text[0].text = score.ToString();
        if (MapLoader.MapPlayer.HightScore < score)
            text[2].text = score.ToString();
        else
            text[2].text = MapLoader.MapPlayer.HightScore.ToString();

        text[1].text = ((int)MapLoader.time * 500).ToString();
        setStar(score);

    }

    public void SaveProgress()
	{
		if (MapLoader.MapPlayer.HightScore < score)
            MapLoader.MapPlayer.HightScore = score;
        int s = setStar(score);
        if (MapLoader.MapPlayer.Stars < s)
            MapLoader.MapPlayer.Stars = s;
        DataLoader.DataPlayer[MapLoader.MapPlayer.Level - 1] = MapLoader.MapPlayer;
        PlayerPrefsSerializer p = new PlayerPrefsSerializer();
        p.Maps = p.LoadPref();
        p.Update(MapLoader.MapPlayer.Level, MapLoader.MapPlayer);
        Player m = new Player();
        m = p.Maps[MapLoader.MapPlayer.Level];
        m.UnLocked = true;
        if (MapLoader.MapPlayer.Level < 297)
        {
            p.Update(MapLoader.MapPlayer.Level + 1, m);
            DataLoader.DataPlayer[MapLoader.MapPlayer.Level].UnLocked = true;
        }
        MapLoader.MapPlayer = m;
	}

	public void Next()
	{
		if (MapLoader.MapPlayer.Level != 297)
        {
            SceneManager.LoadScene("PlayScene");
        }
        else 
            SceneManager.LoadScene("HomeScene");
	}

    int setStar(long _score)
    {
        int tmp = 1;
        if (_score > 80000)
        {
            tmp = 3;
            stars[0].GetComponent<Animator>().enabled = true;
            stars[1].GetComponent<Animator>().enabled = true;
            stars[2].GetComponent<Animator>().enabled = true;
        }
        else if (_score > 60000)
        {
            tmp = 2;
            stars[0].GetComponent<Animator>().enabled = true;
            stars[1].GetComponent<Animator>().enabled = true;
        }
        else
        {
            tmp = 1;
            stars[0].GetComponent<Animator>().enabled = true;
        }
        return tmp;
    }
}