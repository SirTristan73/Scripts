using System.Collections.Generic;
using UnityEngine;

public  class Weapon : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _player;
    public List<GameObject> _bulletsFired = new List<GameObject>();
    [SerializeField] float _bulletSpeed = 10f;
    void Start()
    {
        for(int i= 0; i<5;i++){
        Instantiate(_bullet,transform.position,Quaternion.identity);
        _bulletsFired.Add(_bullet);}
    }
    void FixedUpdate()
    {
        foreach(GameObject i in _bulletsFired){
        i.transform.Translate(Vector3.forward*_bulletSpeed*Time.fixedDeltaTime);}
    }

}
