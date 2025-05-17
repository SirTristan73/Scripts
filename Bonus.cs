using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private const float NewPosOffset = 0.2f;

    [Header("Settings")]
    [SerializeField] float _speed = 1f;
    [SerializeField] Vector3 _width = new Vector3(3f, 0f, 0f);

    private float _movementFactor;
    private Vector3 _endPosition;  
    private Vector3 _startPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GameTags.Bullet))
        {
            Vector3 clonePosition = new Vector3(NewPosOffset, 0f, NewPosOffset) + other.transform.position;
            Instantiate(other,clonePosition,Quaternion.identity);
        }        
    }
    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + _width;
    }

    private void FixedUpdate()
    {
       _movementFactor = Mathf.PingPong(Time.time * _speed,1f); // no idea what's this, it looks really sus but i am not familiar with pingpong func
       transform.position = Vector3.Lerp(_startPosition,_endPosition,_movementFactor);
    }

}

