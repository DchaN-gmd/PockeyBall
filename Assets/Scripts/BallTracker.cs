using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Ball _ball;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(_transform.position.x, _ball.transform.position.y, _transform.position.z);
        transform.position = Vector3.Lerp(_transform.position, targetPosition, _speed*Time.fixedDeltaTime);
    }
}
