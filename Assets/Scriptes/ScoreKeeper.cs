using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _correctAnswer = 0;
    private int _questionSeen = 0;

    public int GetCorrectAnswer()
    {
        return _correctAnswer;
    }

    public void IncrementCorrectAnswer()
    {
        _correctAnswer++;
    }

    public int GetQuestionSeen()
    {
        return _questionSeen;
    }

    public void IncrementQuestionSeen()
    {
        _questionSeen++;
    }

    public string CalculateScore()
    {
        return $"{_correctAnswer} из {_questionSeen}";
    }

    //public int CalculateScorePercent()
    //{
    //    return Mathf.RoundToInt(_correctAnswer / (float)_questionSeen * 100);//Рассчитать в процентах и округить до инта
    //}
}
