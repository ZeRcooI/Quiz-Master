using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class QuestionsSO : ScriptableObject
{
    private const int _minQuantityLines = 2;
    private const int _maxQuantityLines = 6;

    [SerializeField] private int _correctAnswerIndex;
    [TextArea(_minQuantityLines, _maxQuantityLines)]
    [SerializeField] private string _question = "Enter new question text here";
    [TextArea(_minQuantityLines, _maxQuantityLines)]
    [SerializeField] private string[] _answers = new string[4];

    public string GetQuestion()
    {
        return _question;
    }

    public string GetAnswer(int index)
    {
        return _answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return _correctAnswerIndex;
    }
}