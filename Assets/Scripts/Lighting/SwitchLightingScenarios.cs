using UnityEngine;
using UnityEngine.Rendering;


public class SwitchLightingScenarios : MonoBehaviour
{
    private ProbeVolumePerSceneData sceneProbeVolumeData;
    

    void Start()
    {
        sceneProbeVolumeData = FindFirstObjectByType<ProbeVolumePerSceneData>();
    }


    public void Switch(bool value)
    {
        sceneProbeVolumeData.enabled = value;
    }
}