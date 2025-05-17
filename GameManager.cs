using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header ("Stats")]
    private float _currentTime;
    private float _totalTime;
    private float _totalPoints;

    [Header("Conditions")]
    public bool _isGameStarted = false;
    
    [Tooltip("Actions")]
    public event Action<float> _lifeCycle;
    public event Action<float> _totalLifeCycle;


    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
       
        _currentTime = Time.fixedDeltaTime;
        _totalTime += Time.fixedDeltaTime;
        _lifeCycle?.Invoke(_currentTime);
        _totalLifeCycle?.Invoke(_totalTime);
        UIManager.Instance.GetCurrentTime(_totalTime);
        MainMenuUI.Instance.TotalTimeCounter(_totalTime);
    }

    public void AddPoints(float points)
    {
        float currentPoints = 0;
        currentPoints += points;
        UIManager.Instance.AddPointsProcess(currentPoints);
        _totalPoints += currentPoints;
        MainMenuUI.Instance.TotalPointsCounter(_totalPoints);
    }
    public void StartGameProcess(bool gameStarted)
    {
        SceneManager.LoadScene(SceneManagerInfo.MainPlayScene);
        _isGameStarted = gameStarted;        
    }
}

