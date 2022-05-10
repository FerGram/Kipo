using UnityEngine;
using UnityEngine.SceneManagement;

public class Endpoint : MonoBehaviour
{
    [SerializeField] ParticleSystem _doorParticles;

    private GameController _gameController;
    private AudioManager _audioManager;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement _player = FindObjectOfType<PlayerMovement>();

            _player.GetComponent<PlayerMovement>().enabled = false;
            _player.gameObject.SetActive(false);

            var particles = Instantiate(_doorParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration);

            _audioManager.LevelPassed();

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            _gameController.WinLevel(nextSceneIndex);
            Invoke("LoadNext", 2.5f);
        }
    }

    private void LoadNext()
    {
        FindObjectOfType<SceneHandler>().LoadNextLevel();
    }
}
