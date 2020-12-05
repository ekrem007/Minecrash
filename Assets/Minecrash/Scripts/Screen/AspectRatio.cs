using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI.Extensions;
using AppodealAds.Unity.Api;
public class AspectRatio : MonoBehaviour
{
    public GameObject scene;
    Vector2 resolution;
    float camSize;
    Camera cam;
    string activeScene;
    void Start()
    {
        activeScene = SceneManager.GetActiveScene().name;
        cam = this.GetComponent<Camera>();
        camSize = cam.orthographicSize;
        resolution = new Vector2(Screen.width, Screen.height);

        if (activeScene == "PlayScene")
        {
            OptimizeSize();
        }
    }
    void Update()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            if (activeScene == "PlayScene")
            {
                OptimizeSize();
            }
            else
            {
                SceneManager.LoadScene(activeScene);
            }
            resolution.x = Screen.width;
            resolution.y = Screen.height;
        }
    }
    public void OptimizeSize()
    {
        float s = (float)Screen.height / (float)Screen.width - (float)16 / (float)9;

        if (Screen.width > Screen.height)
        {
            cam.orthographicSize = camSize + (s * 1.5f);

            scene.transform.localPosition = new Vector2(-0.5f, -0.85f);
            scene.transform.localRotation = Quaternion.Euler(0, 0, 90);

            Appodeal.hide(Appodeal.BANNER);
            Appodeal.show(Appodeal.BANNER_RIGHT);
        }
        else
        {
            cam.orthographicSize = camSize + (s * 4);

            scene.transform.localPosition = new Vector2(0, 0);
            scene.transform.localRotation = Quaternion.Euler(0, 0, 0);

            Appodeal.hide(Appodeal.BANNER);
            Appodeal.show(Appodeal.BANNER_BOTTOM);
        }
    }
}