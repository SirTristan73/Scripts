using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private const string _timerText = "Current time : ";
    private const string _scoreBoardText = "Current Score : ";

    [SerializeField] TMP_Text _timeBoard;
    [SerializeField] TMP_Text _scoreBoard;

    private readonly StringBuilder _stringBuilder = new StringBuilder(128);

    public void GetCurrentTime(float currentTime)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(_timerText);
        _stringBuilder.Append(Time.time.ToString("F1"));

        _timeBoard.text = _stringBuilder.ToString();    
    }

    public void AddPointsProcess(float points)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(_scoreBoardText);
        _stringBuilder.Append(points.ToString());

        _scoreBoard.text = _stringBuilder.ToString();    
    }
}
