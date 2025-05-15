using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
    // Vector3 _direction ;

    void FixedUpdate()
    {
      // _direction = Vector3.forward * _bulletSpeed * Time.fixedDeltaTime;
      // // _rb.linearVelocity = _direction;
      transform.Translate(Vector3.forward * _bulletSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag ("Bullet")){}
      else {Destroy(this.gameObject);}
    }
}
