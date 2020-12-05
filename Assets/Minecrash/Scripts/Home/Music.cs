using UnityEngine;
using System.Collections;
public class Music : MonoBehaviour
{
    public AudioClip[] bgMusic;
    void Awake()
    {
        RandomBGMusic();
        StartCoroutine(ChangeClip());

        if (FindObjectsOfType<Music>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    IEnumerator ChangeClip()
    {
        yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);
        RandomBGMusic();
    }
    public void RandomBGMusic()
    {
        GetComponent<AudioSource>().clip = bgMusic[Random.Range(0, bgMusic.Length)];
        GetComponent<AudioSource>().Play();
    }
    public void MusicON()
    {
        GetComponent<AudioSource>().mute = false;
    }
    public void MusicOFF()
    {
        GetComponent<AudioSource>().mute = true;
    }
}