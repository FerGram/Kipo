using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class LookAt : MonoBehaviour
{
	[SerializeField] Vector3 offset;

	Transform door;
    Transform player;

    // Start is called before the first frame update
    void Awake()
    {
		transform.parent = GameObject.Find("World").GetComponent<Transform>();

		
		door = GameObject.FindGameObjectWithTag("Door").transform;
		//TODO when Door changes, pass on the new door.
    }

	private void Start()
	{
		player = GameObject.Find("Player").GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
    {
		transform.position = player.position + offset;
        
        //Rotacion de la flecha
        Quaternion rotation = Quaternion.LookRotation(door.transform.position - transform.position, transform.TransformDirection(Vector3.up));

        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        transform.right = door.position - transform.position;
    }
}
