using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;
    [SerializeField] UIManager _uiManager;
    private float _currentTime;
    private float _totalTime;
    private float _currentPoints;
    public event Action<float> _timer ;
    private void Awake()
    {
        Instance=this;
    }
    private void FixedUpdate()
    {
        _currentTime = Time.fixedDeltaTime;
        _totalTime += Time.fixedDeltaTime;
        _timer?.Invoke(_currentTime);
        _uiManager.GetCurrentTime(_totalTime);
    }
    public void AddPoints (float points)
    {         
        _currentPoints += points;
        _uiManager.AddPointsProcess(_currentPoints);
    }

}

