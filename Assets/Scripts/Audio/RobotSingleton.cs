using UnityEngine;

public class RobotSingleton : MonoBehaviour
{
    private static RobotSingleton Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
}
