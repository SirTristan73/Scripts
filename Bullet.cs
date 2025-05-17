using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;

    void FixedUpdate()
    {
      transform.Translate(Vector3.forward * _bulletSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag ("Bullet")){}
      else {Destroy(this.gameObject);}
    }
}
