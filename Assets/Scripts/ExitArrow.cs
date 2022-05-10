using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExitArrow : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 5f;
    private Transform _target;

    void Start()
    {
        _target = FindObjectOfType<Endpoint>().transform;
    }

    void Update()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _turnSpeed * Time.deltaTime);
    }
}
