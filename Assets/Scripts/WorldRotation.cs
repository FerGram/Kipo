using UnityEngine;

public class WorldRotation : MonoBehaviour
{
	private float _rotation  = 90f;
	private float[] _rotValues;
	public static bool _isRotating { get; private set; }

	private LocateAllEnemies _locateAllEnemiesS;
	private GameObject[] _enemies;
	Vector3 targetUp;

	private void Awake()
	{
		_rotValues = new float[3];
		_rotValues[0] = 90f;
		_rotValues[1] = 180f;
		_rotValues[2] = 270f;

		_locateAllEnemiesS = GetComponent<LocateAllEnemies>();
		if (_locateAllEnemiesS != null)
        {
			_enemies = _locateAllEnemiesS._enemies;
		}

		targetUp = new Vector3(0, 1);
	}

	private void Start()
	{
		_isRotating = false;
	}

	void Update()
    {
        if (LeanTween.isTweening())
		{
			_isRotating = true;
		}
        else
		{
			_isRotating = false;
		}
    }

    public void RotateWorld()
    {
        if (!_isRotating)
        {
			int randI = Random.Range(0, 3);

			

			while (_rotation == _rotValues[randI])
			{
				randI = Random.Range(0, 3);
			}

			_rotation = _rotValues[randI];
			Debug.Log(_rotation);

			LeanTween.rotateZ(gameObject, _rotation, 2f).setEaseInOutBack();
        }
    }
}
