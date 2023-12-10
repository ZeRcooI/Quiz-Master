using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class Questions : ScriptableObject
{
    private const int _minQuantityLines = 2;
    private const int _maxQuantityLines = 3;
    private const int _linesNumber = 4;

    [SerializeField] private int _correctAnswerIndex;
    [TextArea(_minQuantityLines, _maxQuantityLines)]
    [SerializeField] private string _question = "Enter new question text here";
    [TextArea(_minQuantityLines, _maxQuantityLines)]
    [SerializeField] private string[] _answers = new string[_linesNumber];

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