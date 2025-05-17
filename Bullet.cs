using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    // Vector3 _direction ;

    private void FixedUpdate()
    {
      // _direction = Vector3.forward * _speed * Time.fixedDeltaTime;
      // // _rb.linearVelocity = _direction;
        transform.Translate(Vector3.forward * (_speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag(GameTags.Bullet))
        {
            Destroy(this.gameObject);
        }
    }
}
