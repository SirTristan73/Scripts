using System.Collections.Generic;
using UnityEngine;

public enum EnemyType : byte {
    Normal = 0,
    Big = 1,
    Boss = 2
}

public class EnemyManager : MonoBehaviour
{

    [System.Serializable]
    private struct EnemyPrefabKeyPair {
        public EnemyType _type;
        public GameObject _prefab;
        [Range(0.01f, 1f)] public float _spawnChance;
        public int _pointsReward;
    }

    [Header("References")]
    [SerializeField] private List<EnemyPrefabKeyPair> _enemyData; // нужно отсортировать всегда так чтобы по шансам шло - от низкого до наибольшего. в инете примеров куча
    [SerializeField] private Transform _enemyParent;

    [Header("Spawn Settings")]
    [SerializeField] private float _spawnTime = 10f;
    [SerialzieField] private float _xSpawnPositionRange = 3f;

    private float _timeSinceLastSpawn = 0;
    private float _enemyCount = 5f;
    private float _bigSpawnChance = 0.1f;
    private float _bossSpawnChance = 0.3f;

    public int GetPointsRewardForEnemyType(EnemyType type) {
        foreach(var enemyData in _enemyData) {
            if (enemyData._type == type) {
                return enemyData._pointsReward;
            }
        }

        Debug.unityLogger.LogError($"No such enemy in enemies prefabs list: {type}")
        return 0;
    }

    private void Update()
    {
        _timeSinceLastSpawn -= Time.deltaTime;
        if (_timeSinceLastSpawn <= 0f)
        {
            SpawnWave();
            _timeSinceLastSpawn = _spawnTime;
        }
    }

    private void SpawnWave()
    {        
        for (int i = 0; i <= _enemyCount; i++)
        {
            var randomValue = Random.value;
            foreach (var enemyData in _enemyData) {
                if (enemyData._spawnChance <= randomValue) {
                    float x = Random.Range(-_xSpawnPositionRange, _xSpawnPositionRange);
                    float y = _enemyParent.transform.position.y;
                    float z = _enemyParent.transform.position.z;

                    Vector3 spawnPos = new Vector3(x, y, z);
                    Instantiate(enemyData._prefab, spawnPos, Quaternion.identity, _enemyParent);
                    break;
                }
            }

            // оставил чтобы сказать что здесь вполне вероятен баг - каждый раз когда ты вызываешь Random.value - ты получаешь новое рандомное значение, следовательно каждый иф - это новое значение
            // if (Random.value <= _bigSpawnChance){_enemyToSpawn = 1;}
            // else if (Random.value <= _bossSpawnChance){_enemyToSpawn = 2;}
            // else{_enemyToSpawn = 0;}
        }

        _enemyCount++;
    }

    private GameObject GetPrefabForEnemyType(EnemyType type) {
        foreach(var enemyData in _enemyData) {
            if (enemyData._type == type) {
                return enemyData._prefab;
            }
        }

        Debug.unityLogger.LogError($"No such enemy in enemies prefabs list: {type}")
        return null;
    }

    private EnemyPrefabKeyPair GetDataForEnemyType(EnemyType type) {
        foreach(var enemyData in _enemyData) {
            if (enemyData._type == type) {
                return enemyData;
            }
        }

        Debug.unityLogger.LogError($"No such enemy in enemies prefabs list: {type}")
        return default;
    }
}
