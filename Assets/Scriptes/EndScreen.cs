using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finalScoreText;
    private ScoreKeeper _scoreKeeper;

    public void ShowFinalScore()
    {
        _finalScoreText.text = $"Игра завершена!!!\n Ваш итог: {_scoreKeeper.CalculateScore()}.";
    }

    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
}