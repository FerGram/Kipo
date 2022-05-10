using UnityEngine;

public class JumpOnEnemy : MonoBehaviour
{
    [SerializeField] float _jumpMultiplier = 1f;
    [SerializeField] ParticleSystem _jumpOnEnemyParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "GroundCheck")
        {
            FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>().Jump(_jumpMultiplier);
            var particles = Instantiate(_jumpOnEnemyParticles, transform.position, Quaternion.identity);
            Destroy(particles, particles.main.duration);
            GameObject parent = transform.parent.gameObject;
            parent.GetComponent<EnemyHealth>().DestroySelf();
        }
    }
}
