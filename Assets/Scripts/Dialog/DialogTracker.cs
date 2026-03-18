using UnityEngine;


public class DialogTracker : MonoBehaviour
{
    public static DialogTracker Instance;
    public static int fileNum;


    void Awake()
    {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }
}