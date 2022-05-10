using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RandomPlayerMovement : MonoBehaviour
{
    [SerializeField] float _timeBetweenBehaviours = 4f;
    [SerializeField] Image[] _behaviourImages;
    [SerializeField] Image _warningImage;
    
    public Queue<RandomBehaviourEnum> _behaviours = new Queue<RandomBehaviourEnum>();
    public List<RandomBehaviourEnum> _availableBehaviours ;

    private PlayerMovement _player;
    private WorldRotation _world;

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
        _world = FindObjectOfType<WorldRotation>().GetComponent<WorldRotation>();

        if (_availableBehaviours.Count != 0)
        {
            EnqueNewBehaviour();
            StartCoroutine(SetRandomBehaviour());
        }  
    }

	private void Update()
	{
		if (WorldRotation._isRotating)
		{
			Vector3 targetUp = new Vector3(0, Mathf.Sign(-_player.gravity), 0);
			float damping = 8;
			transform.up = Vector3.Slerp(transform.up, targetUp, damping);
		}
	}

    IEnumerator SetRandomBehaviour()
    {
        EnqueNewBehaviour();
        yield return new WaitForSeconds(_timeBetweenBehaviours - 1);
        UpdateUI();

        yield return new WaitForSeconds(1.5f);
        ExecuteBehaviour();
        StartCoroutine(SetRandomBehaviour());
    }
    private void EnqueNewBehaviour()
    {
        int random = Random.Range(0, _availableBehaviours.Count);
        _behaviours.Enqueue(_availableBehaviours[random]);
    }
    private void ExecuteBehaviour()
    {
        if(_behaviours.Peek() == RandomBehaviourEnum.Jump) { _player.Jump(1.3f); }
        else if(_behaviours.Peek() == RandomBehaviourEnum.ReverseGravity) 
        { 
            _player.GetComponent<GravityChange>().ReverseGravity(); 
        }
        else { _world.RotateWorld(); }
        _behaviours.Dequeue();
    }


    //TODO Remove
    private void UpdateUI()
    {
        foreach (Image image in _behaviourImages)
        {
            if (image.gameObject.GetComponent<UIImages>().GetBehaviour() == _behaviours.Peek())
            {
                _warningImage.gameObject.SetActive(true);
                _warningImage.sprite = image.sprite;
            }
        }
        StartCoroutine(DisableUIImages());
    }

    IEnumerator DisableUIImages()
    {
        yield return new WaitForSeconds(1.5f);
        _warningImage.gameObject.SetActive(false);
    }

}
