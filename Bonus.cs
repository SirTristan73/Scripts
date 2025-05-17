using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [Header("Other Objects")]
    private float _newPos = 0.2f;
    [Header("This Object")]
    [SerializeField] float _speed = 1f;
    private float _movementFactor;
    [SerializeField]  Vector3 _width = new Vector3(3,0,0);
    private Vector3 _endPosition;  
    private Vector3 _startPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(GametagKeeper._bulletTag))
        {
        Vector3 clonePosition = new Vector3 (_newPos,0,_newPos) + other.transform.position;
        Instantiate (other,clonePosition,Quaternion.identity);
        }        
    }
    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + _width;
    }
    private void FixedUpdate()
    {
       _movementFactor = Mathf.PingPong(Time.time * _speed,1f);
       transform.position = Vector3.Lerp(_startPosition,_endPosition,_movementFactor);
    }

}

