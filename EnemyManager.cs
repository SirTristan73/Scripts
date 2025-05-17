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
    private float _timeSinceLastSpawn = 0;
    [SerializeField] float _spawnTime = 10f;
    [SerializeField] float _xPositionMin;
    [SerializeField] float _xPositionMax;

    [Header("EnemyTypes")]
    private const int _bigEnemyId = 1;
    private const int _bossEnemyid = 2;

    private void Start()
    {
        GameManager.Instance._lifeCycle += TimeWindow;
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
            if (Random.value <= _bigSpawnChance)
            { _enemyToSpawn = _bigEnemyId;}
            else if (Random.value <= _bossSpawnChance)
            { _enemyToSpawn = 2;}
            else{_enemyToSpawn = _bossEnemyid;}

            float xClamp = Random.Range(_xPositionMin,_xPositionMax);
            float yClamp = _enemyWave.transform.position.y;
            float zClamp = _enemyWave.transform.position.z;
            Vector3 spawnPos = new Vector3(xClamp,yClamp,zClamp);
            Instantiate(_enemy[_enemyToSpawn],spawnPos,Quaternion.identity,_enemyWave);
        }
        _enemyCount++;
    }
}
