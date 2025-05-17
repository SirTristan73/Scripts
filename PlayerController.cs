using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Weapon _mainWeapon;
    [SerializeField] private float _speed = 20f;

    private Vector2 _currentMoveInput;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Control.Instance._fire += FiringInput;
        Control.Instance._move += GetMovingVector;
    }

    public void FixedUpdate()
    {
        var _deltaTime = Time.fixedDeltaTime;

        Vector3 movingVector = new Vector3(_currentMoveInput.x, 0f, 0f) * (_speed * _deltaTime);
        _rb.linearVelocity = movingVector;        
    }

    private void FiringInput(float fire)
    {
        _mainWeapon._isFireEventActive = fire > 0;
    }

    private void GetMovingVector(Vector2 input)
    {
        _currentMoveInput = input;
    }
}
