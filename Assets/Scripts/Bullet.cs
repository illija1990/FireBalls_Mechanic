using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private void Start()
    {
        _moveDirection = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Block _block))
        {
            _block.Break();
            Destroy(gameObject);
        }
        if(other.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        Rigidbody _ballrigidbody = GetComponent<Rigidbody>();
        _ballrigidbody.AddExplosionForce(_bounceForce, transform.position, _bounceRadius);
    }
}
