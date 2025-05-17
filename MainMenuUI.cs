using System.Text;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance;
    [SerializeField] TMP_Text _totalPointsCounter;
    [SerializeField] TMP_Text _totalTimeCounter;

    private readonly StringBuilder _stringBuilder = new StringBuilder();

    private const string _totalPointsText = "Your Total Points : ";
    private const string _totalTimeText = "Your Total Playtime : ";

    public void OnEnable()
    {
        Instance = this;
    }
    public void TotalPointsCounter(float points)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(_totalPointsText);
        _stringBuilder.Append(points.ToString());
        _totalPointsCounter.text = _stringBuilder.ToString();
    }
    public void TotalTimeCounter(float time)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(_totalTimeText);
        _stringBuilder.Append(time.ToString("F1"));
        _totalTimeCounter.text = _stringBuilder.ToString();

    }
    
}
