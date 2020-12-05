using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class loadingwait : MonoBehaviour
{
    public AsyncOperation asyncLoad;
    public Slider slider;
    void Start()
    {
        StartCoroutine(LoadLevel("WorldSelect"));
    }
    IEnumerator LoadLevel(string sceneName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    void Update()
    {
        slider.value = Mathf.Clamp01(asyncLoad.progress / .9f);
    }
}