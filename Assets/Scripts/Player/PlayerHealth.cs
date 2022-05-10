using UnityEngine;
using UnityEngine.Analytics;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem _deathParticles;

    private AudioManager _audioManager;

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Spike")
        {
            Instantiate(_deathParticles, transform.position, Quaternion.identity, GameObject.Find("World").transform);

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<RandomPlayerMovement>().enabled = false;

            gameObject.SetActive(false);
            _audioManager.PlayerDeath();

            Invoke("PlayerDeath", 1f);
        }
    }

    void PlayerDeath()
    {
        FindObjectOfType<SceneHandler>().ReloadLevel();
    }
}
