using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;
    private float _currentTime;
    private float _totalTime;
    private float _currentPoints;
    public event Action<float> _lifeCycle ;
    public event Action<float> _totalLifeCycle;
    
    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        _currentTime = Time.fixedDeltaTime;
        _totalTime += Time.fixedDeltaTime;
        _lifeCycle?.Invoke(_currentTime);
        _totalLifeCycle?.Invoke(_totalTime);
        UIManager.Instance.GetCurrentTime(_totalTime);
    }
    
    public void AddPoints(float points)
    {
        _currentPoints += points;
        UIManager.Instance.AddPointsProcess(_currentPoints);
    }
}

