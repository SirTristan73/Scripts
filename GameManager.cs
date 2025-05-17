using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;

    [Header("References")]
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private EnemyManager _enemyManager;

    public LifecycleEventHandler LifecycleEventHandlerInstance { get; private set; } // not needed for now but I left as an example

    private float _currentPoints;

    private void Awake()
    {
        Instance=this;
        LifecycleEventHandlerInstance = new LifecycleEventHandler();
    }

    private void FixedUpdate()
    {
        _currentTime = Time.fixedDeltaTime;
        _totalTime += Time.fixedDeltaTime;
        _timer?.Invoke(_currentTime);
        _totalTimer?.Invoke(_totalTime);
        _uiManager.GetCurrentTime(_totalTime);
    }

    public void NotifyEnemyDestroy(EnemyType type) {
        var points = _enemyManager.GetPointsRewardForEnemyType(type);
        _currentPoints += points;
        _uiManager.AddPointsProcess(_currentPoints);
    }
}