using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LocateAllEnemies : MonoBehaviour
{
	[HideInInspector] public GameObject[] _enemies;
	[SerializeField] ParticleSystem _spawnParticles;
	bool _isFirstTime;

    // Start is called before the first frame update
    void Start()
    {
		_isFirstTime = GameController._isFirstTryOnThisLevel; 

		if (_isFirstTime)
		{
			_enemies = GameObject.FindGameObjectsWithTag("Enemy");

			StartCoroutine(PlaySpawnParticles());

			EnemiesActive(false);
		}
    }

	IEnumerator PlaySpawnParticles()
    {
		yield return new WaitForSeconds(2f);
        foreach (GameObject enemy in _enemies)
        {
			if(enemy.GetComponent<EnemyHealth>() != null)
            {
				var particles = Instantiate(_spawnParticles, enemy.transform.position, Quaternion.identity);
				Destroy(particles, 5f);
			}
        }
    }


	public void EnemiesActive(bool isActive)
	{
		foreach (GameObject enemy in _enemies) enemy.SetActive(isActive);
	}
}
