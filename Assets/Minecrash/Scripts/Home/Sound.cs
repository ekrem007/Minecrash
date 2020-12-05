using UnityEngine;
public class Sound : MonoBehaviour
{
    public AudioClip[] effect;
    public AudioClip[] block;
    void Awake()
    {
        if (FindObjectsOfType<Sound>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void blockCrash(int type)
    {
        if (type == 9)
            GetComponent<AudioSource>().PlayOneShot(block[4]);
        else
            GetComponent<AudioSource>().PlayOneShot(block[type]);
    }
    public void bliz()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[0]);
    }
    public void boom()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[1]);
    }
    public void click()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[2]);
    }
    public void elec()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[3]);
    }
    public void fail()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[4]);
    }
    public void icecash()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[5]);
    }
    public void lockcash()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[6]);
    }
    public void pass()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[7]);
    }
    public void unSwap()
    {
        GetComponent<AudioSource>().PlayOneShot(effect[8]);
    }

    public void SoundON()
    {
        GetComponent<AudioSource>().mute = false;
    }
    public void SoundOFF()
    {
        GetComponent<AudioSource>().mute = true;
    }
}
