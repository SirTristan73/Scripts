using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [Header("Elements")]
    Rigidbody _rb;
    [SerializeField] List <ParticleSystem> _mainWeapon;
    [Header("InputInfo")]
    private Vector2 _currentMoveInput;
    [Header("SpeedVar")]
    [SerializeField] float _playerSpeed = 20f;

       void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Control.Instance._fire += FiringInput;
        Control.Instance._move += GetMovingVector;
    }
    private void FiringInput  (float fire)
    {
        if (fire > 0){_mainWeapon[0].Play();}
        else{_mainWeapon[0].Stop();}
    }
    private void GetMovingVector (Vector2 input)
    {
        _currentMoveInput = input;
    }
    public void FixedUpdate()
    {
        //Moving
        var _deltaTime = Time.fixedDeltaTime;
        Vector3 movingVector = 
        new Vector3(_currentMoveInput.x,0,0)*_playerSpeed*_deltaTime;
        _rb.linearVelocity = movingVector;        
    }
}
