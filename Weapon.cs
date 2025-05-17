using System.Collections.Generic;
using UnityEngine;

public  class Weapon : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _player;
    [SerializeField] float _shootingSpeed = 1f;
    private float _nextShotTime = 0f;
    public bool _isFireEventActive = false;
    public List<GameObject> _bulletsFired = new List<GameObject>();

    void Start()
    {
        GameManager.Instance._totalLifeCycle += FireRate;
    }
 
    void FireWeapon()
    {
        Instantiate(_bullet,transform.position,Quaternion.identity);
        _bulletsFired.Add(_bullet);
    }
    void FireRate(float time)
    {
        if (_isFireEventActive && time >= _nextShotTime)
        {
            FireWeapon();
            _nextShotTime = time + 1 / _shootingSpeed;
        }
    }

}
