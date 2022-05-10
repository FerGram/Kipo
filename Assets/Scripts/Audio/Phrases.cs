using UnityEngine;
using UnityEngine.SceneManagement;

public class Phrases : MonoBehaviour
{
    [SerializeField] AudioClip _clipToPlay;
    [SerializeField] int _sceneToPlay = 0;
    //[SerializeField] bool _onlyOnce;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public void SetNewAudioManager()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool inSameScene = SceneManager.GetActiveScene().buildIndex == _sceneToPlay;

        if (collision.gameObject.tag == "Player" && inSameScene)
        {
            _audioManager.PlayClip(_clipToPlay);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
