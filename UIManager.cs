using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TMP_Text _timeBoard;
    [SerializeField] TMP_Text _scoreBoard;
    private const string _timerText = "Current time : ";
    private const string _scoreBoardText = "Current Score : ";
    private readonly StringBuilder _stringBuilder = new StringBuilder();

    public void OnEnable()
    {
        Instance = this;
    }

    public void GetCurrentTime(float currentTime)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(_timerText);
        _stringBuilder.Append(currentTime.ToString("F1"));
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
