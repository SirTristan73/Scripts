using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
  void FixedUpdate()
    {
        transform.Translate(Vector3.forward*_bulletSpeed*Time.fixedDeltaTime);  
    }
}
