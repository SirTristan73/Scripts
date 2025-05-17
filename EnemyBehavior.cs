using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class EnemyBehavior : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private EnemyType _type;
    [SerializeField] private float _speed = 20f;
    [SerializeField] private int _startHealth = 3f;
    [SerializeField] private float _points = 1f;

    private Rigidbody _rb;
    private Animator _animator;

    private int _currentHealth;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Start() {
        _currentHealth = _startHealth;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GameTags.Bullet))
        {
          _currentHealth--;
          Destroy(other.gameObject); // вообще не нравится, но трогать не буду. должна быть система которая правильно говорит пульке, хотя бы что-то типа // other.transform.GetComponent<Bullet>().OnCollide(); - и там уже пулька решает что ей делать
          _animator.SetTrigger("Hit");
        }       
    }
    
    private void FixedUpdate()
    {
        Vector3 enemyDirection = Vector3.back * (Time.fixedDeltaTime * _speed);
        _rb.linearVelocity = enemyDirection;
        
        if (_currentHealth <= 0) {
            GameManager.Instance.NotifyEnemyDestroy(_type);
            Destroy(this.gameObject);
        }
    }
}
