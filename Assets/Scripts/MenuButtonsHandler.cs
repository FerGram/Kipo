using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonsHandler : MonoBehaviour
{
    [SerializeField] LevelSelector _levelSelector;

    public void StartClick()
    {
        FindObjectOfType<AudioSource>().Play();
        Invoke("StartGame", 2.5f);
    }
    public void StartGame()
    {
        SceneHandler scene = FindObjectOfType<SceneHandler>().GetComponent<SceneHandler>();
        scene.LoadNextLevel();
    }

    public void MoveButtonsRight()
    {
        RectTransform rect = GetComponent<RectTransform>();
        LeanTween.moveX(rect, 0, 1f).setEaseInOutBack();
    }

    public void MoveButtonsLeft()
    {
        RectTransform rect = GetComponent<RectTransform>();
        LeanTween.moveX(rect, -2100, 1f).setEaseInOutBack();
    }

    public void YouCannotQuit()
    {
        Application.Quit();
    }
}
