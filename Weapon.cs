using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private float _fireRate = 1f; // shots per second

    [HideInInspector] // не нужно показывать в эдиторе то, что зависит от инпута
    public bool _isFireEventActive = false;

    private ushort _framesBetweenShots;
    private long _nextFireShotFrameCount;

    private void Start()
    {
        // in case you'd have multiple fire modes where firerate would change - this needs to be a separate func, careful
        _framesBetweenShots = _fireRate / 60f; // 60 frames in fixed update = 1s
    }
 
    private void FireWeapon()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        _nextFireShotFrameCount = Time.frameCount + _framesBetweenShots;
    }

    private void FixedUpdate() {
        if (!_isFireEventActive)
        {
            return;
        }

        if (Time.frameCount < _nextFireShotFrameCount) {
            return;
        }

        FireWeapon();
    }
}
