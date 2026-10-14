using UnityEngine;
using UnityEngine.Rendering;


public class SwitchLightmaps : MonoBehaviour
{
    private MeshRenderer[] renderers;
    private int[] originalLightmapIndices;

    
    public void Start()
    {
        renderers = FindObjectsByType<MeshRenderer>(FindObjectsSortMode.None);
        originalLightmapIndices = new int[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            originalLightmapIndices[i] = renderers[i].lightmapIndex;
        }
    }


    public void Switch(bool value)
    {
        if (value)
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                if (originalLightmapIndices[i] != -1) 
                {
                    renderers[i].lightmapIndex = originalLightmapIndices[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].lightmapIndex = -1; // -1 means no lightmap assigned
            }
        }
    }
}