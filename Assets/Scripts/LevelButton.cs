using UnityEngine;

public class LevelButton : MonoBehaviour
{
    public int index = 0;
    
    public void LoadLevel()
    {
        FindObjectOfType<SceneHandler>().LoadLevel(index);
    }
}
