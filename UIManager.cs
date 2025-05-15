using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{    
    [SerializeField] TMP_Text _timeBoard;
    [SerializeField] TMP_Text _scoreBoard;
    private const string _timerText = "Current time : ";
    private const string _scoreBoardText = "Current Score : ";

    public void GetCurrentTime (float currentTime)
    {
        _timeBoard.text=_timerText + currentTime.ToString("F1");    
    }
    public void AddPointsProcess(float points)
    {
        _scoreBoard.text = _scoreBoardText + points.ToString();
    }
}
