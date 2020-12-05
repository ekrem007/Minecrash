using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour
{
    public Player map = new Player();
    public Image star;
    public Text text;
    public Sprite[] starSprite;
    void Start()
    {
        if (map.UnLocked)
        {
            int lvshow;

            star.sprite = starSprite[map.Stars];
            if (map.Level <= 99)
                lvshow = map.Level;
            else if (map.Level <= 198)
            {
                lvshow = map.Level - 99;
            }
            else
            {
                lvshow = map.Level - 198;
            }

            text.text = lvshow.ToString();
        }
        else
        {
            this.GetComponent<Button>().interactable = false;
            text.text = "";
        }
    }
    public void LoadLevel()
    {
        FindObjectOfType<MenuManager>().ClickSound();
        MapLoader.MapPlayer = map;
        MapLoader.Mode = 1;
        SceneManager.LoadScene("PlayScene");
    }
}