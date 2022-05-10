using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    PlayerMovement _player;

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }

    public void ReverseGravity()
    {
        //Assign oposite gravity.
        _player.SetGravity(-_player.gravity);

        //Rotate the player to face the new gravity.
        Vector3 targetUp = new Vector3(0, Mathf.Sign(-_player.gravity), 0);
        float damping = 8;
        transform.up = Vector3.Slerp(transform.up, targetUp, damping);
    }
}
