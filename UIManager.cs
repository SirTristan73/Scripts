using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TMP_Text _timeBoard;
    [SerializeField] TMP_Text _scoreBoard;

    public void OnEnable()
    {
        Instance = this;
    }

    public void GetCurrentTime(float currentTime)
    {
        _timeBoard.text = currentTime.ToString("F1");
    }
    public void AddPointsProcess(float points)
    {
        _scoreBoard.text = points.ToString();
    }
}
