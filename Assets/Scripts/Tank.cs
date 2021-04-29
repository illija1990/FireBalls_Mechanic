using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _bulletShot;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _delayBetwenShoot;
    [SerializeField] private float _recoilDistamce;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if(Input.GetMouseButton(0))
        {
            if (_timeAfterShoot > _delayBetwenShoot)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - _recoilDistamce, _delayBetwenShoot / 2).SetLoops(2, LoopType.Yoyo);
                _timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _bulletShot.position, Quaternion.identity);
    }
}
