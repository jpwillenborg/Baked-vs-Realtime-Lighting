using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class LightingManager : MonoBehaviour
{
    private SwitchLightmaps switchLightmaps;
    private SwitchLightingScenarios switchLightingScenarios;
    

    void Awake()
    {
        switchLightmaps = GetComponent<SwitchLightmaps>();
        switchLightingScenarios = GetComponent<SwitchLightingScenarios>();
    }


    public void Switch(bool value)
    {
        switchLightmaps.Switch(value);
        switchLightingScenarios.Switch(value);
    }
}