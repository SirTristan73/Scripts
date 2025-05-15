using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Components")]
    Rigidbody _rb;
    Animator _animator;
    UIManager _scoreBoard;
    [Header("Variables")]
    [SerializeField] float _enemySpeed = 20f;
    [SerializeField] float _enemyHP = 3f;
    private const string _bullet = "Bullet";
    [SerializeField] float _points = 1f;
    void OnEnable()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(_bullet))
        {
          _enemyHP --;
          Destroy(other.gameObject);
          _animator.SetTrigger("Hit");
        }       
    }
    void FixedUpdate()
    {
        Vector3 enemyDirection = new Vector3(0,0,-1)*Time.fixedDeltaTime*_enemySpeed;
        _rb.linearVelocity = enemyDirection;
        if (_enemyHP <= 0){Destroy(this.gameObject);GameManager.Instance.AddPoints(_points);}
    }
}
