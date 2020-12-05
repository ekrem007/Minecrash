using UnityEngine;
public class AutoRotation : MonoBehaviour
{
    public static float DeviceDiagonalSizeInInches()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));

        return diagonalInches;
    }
    void Start()
    {
        if (DeviceDiagonalSizeInInches() < 6.5f)
        {
            Screen.orientation = ScreenOrientation.Portrait;
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
        }
    }
}