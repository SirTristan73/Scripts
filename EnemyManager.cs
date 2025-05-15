using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] List<GameObject> _enemy ;
    [SerializeField] Transform _enemyWave;
    [Header("SpawnEnemyCalculations")]
    private float _enemyCount = 5f;
    private float _bigSpawnChance = 0.1f;
    private float _bossSpawnChance = 0.3f;
    private int _enemyToSpawn;
    [SerializeField] float _spawnTime = 10f;
    private float _timeSinceLastSpawn = 0;
    private void Start()
    {
        GameManager.Instance._timer += TimeWindow;        
    }
    private void TimeWindow(float timer)
    {
        _timeSinceLastSpawn += timer;
        if (_timeSinceLastSpawn >= _spawnTime)
        {
            SpawnWave();
            _timeSinceLastSpawn -= _spawnTime;
        }
    }
    void SpawnWave()
    {        
        for(int i = 0; i<=_enemyCount; i++)
        {
        if (Random.value <= _bigSpawnChance){_enemyToSpawn = 1;}
        else if (Random.value <= _bossSpawnChance){_enemyToSpawn = 2;}
        else{_enemyToSpawn = 0;}
        float xClamp = Random.Range(-3,3);
        float yClamp = _enemyWave.transform.position.y;
        float zClamp = _enemyWave.transform.position.z;
        Vector3 spawnPos = new Vector3(xClamp,yClamp,zClamp);
        Instantiate(_enemy[_enemyToSpawn],spawnPos,Quaternion.identity,_enemyWave);
        }
        _enemyCount++;
    }
}
