using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class ChangeShadow : MonoBehaviour
{
    [SerializeField]
    private Light directionalLight;
    [SerializeField]
    private Slider slider;


    public void AdjustShadow(float value)
    {
        directionalLight.shadowStrength = value;
    }


    public void DisplayShadows(bool value)
    {
        if (value)
        {
            directionalLight.shadows = LightShadows.Soft;
            // slider.interactable = value;
        } else
        {
            directionalLight.shadows = LightShadows.None;
            // slider.interactable = value;
        }
        
        slider.interactable = value;
    }
}