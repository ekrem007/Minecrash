using UnityEngine;
public class SkyBoxRotating : MonoBehaviour
{
    public float skyBoxRotatingSpeed; 
     void Update ()
     {
         //Sets the float value of "_Rotation", adjust it by Time.time and a multiplier.
         RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyBoxRotatingSpeed);
     }
}