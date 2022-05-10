using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    [Header("Mute Song Button")]
    [SerializeField] Button _muteSongButton;
    [SerializeField] Sprite _muteSongON;
    [SerializeField] Sprite _muteSongOFF;

    [Header("Mute Audio Button")]
    [SerializeField] Button _muteAudioButton;
    [SerializeField] Sprite _muteAudioON;
    [SerializeField] Sprite _muteAudioOFF;

    public static bool audioOn = true;
    public static bool songOn = true;

    public void MuteAudioButton()
    {
        Camera.main.GetComponent<AudioListener>().enabled = !Camera.main.GetComponent<AudioListener>().enabled;
        if (Camera.main.GetComponent<AudioListener>().enabled)
        {
            _muteAudioButton.image.sprite = _muteAudioON;
        }
        else
        {
            _muteAudioButton.image.sprite = _muteAudioOFF;
        }
    }
    public void MuteSongButton()
    {
        songOn = !songOn;
        if (songOn) 
        { 
            MusicManager.instance.PlaySong();
            _muteSongButton.image.sprite = _muteSongON;
        }
        else 
        { 
            MusicManager.instance.StopSong();
            _muteSongButton.image.sprite = _muteSongOFF;
        }
    }
    public void EscapeButton()
    {
        SceneManager.LoadScene(0);
    }
}
