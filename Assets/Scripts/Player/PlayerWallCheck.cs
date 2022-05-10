using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallCheck : MonoBehaviour
{
    public bool _isColliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Floor")
        {
            _isColliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Floor")
        {
            _isColliding = false;
        }

    }
}
