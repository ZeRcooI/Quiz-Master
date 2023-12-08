using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] private TextMeshProUGUI _questionText;
    [SerializeField] private List<QuestionsSO> _questions = new List<QuestionsSO>();
    [SerializeField] private QuestionsSO _currentQuestion;

    [Header("Answers")]
    [SerializeField] private GameObject[] _answerButtons;
    private int _noAnswerIndex = -1;
    private int _correctAnswerIndex;
    private bool _hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] private Sprite _defaultAnswerSprite;
    [SerializeField] private Sprite _correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] private Image _timerImage;
    private Timer _timer;

    [Header("Scoring")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    ScoreKeeper _scoreKeeper;

    public void OnAnswerSelected(int index)
    {
        _hasAnsweredEarly = true;
        DisplayAnswer(index);

        SetButtonState(false);
        _timer.CancelTimer();

        _scoreText.text = $"Правильно: {_scoreKeeper.CalculateScore()}.";
    }

    private void Start()
    {
        _timer = FindObjectOfType<Timer>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Update()
    {
        _timerImage.fillAmount = _timer.FillFraction;

        if (_timer.LoadNextQuestion)
        {
            _hasAnsweredEarly = false;

            GetNextQuestion();

            _timer.LoadNextQuestion = false;
        }
        else if (!_hasAnsweredEarly && !_timer.GetIsAnsweringQuestion())
        {
            DisplayAnswer(_noAnswerIndex);
            SetButtonState(false);
        }
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == _currentQuestion.GetCorrectAnswerIndex())
        {
            _questionText.text = "Правильно!";

            buttonImage = _answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = _correctAnswerSprite;

            _scoreKeeper.IncrementCorrectAnswer();
        }
        else
        {
            _correctAnswerIndex = _currentQuestion.GetCorrectAnswerIndex();

            string correctAnswer = _currentQuestion.GetAnswer(_correctAnswerIndex);

            _questionText.text = $"Увы! Неверно... Правильный ответ был: \n{correctAnswer}.";

            buttonImage = _answerButtons[_correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = _correctAnswerSprite;
        }
    }

    private void GetNextQuestion()
    {
        if (_questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            _scoreKeeper.IncrementQuestionSeen();
        }
    }

    private void GetRandomQuestion()
    {
        int index = Random.Range(0, _questions.Count);

        _currentQuestion = _questions[index];

        if (_questions.Contains(_currentQuestion))
        {
            _questions.Remove(_currentQuestion);
        }
    }

    private void DisplayQuestion()
    {
        _questionText.text = _currentQuestion.GetQuestion();

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = _currentQuestion.GetAnswer(i);
        }
    }

    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            Image buttonImage = _answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = _defaultAnswerSprite;
        }
    }

    private void SetButtonState(bool state)
    {
        for (int i = 0; i < _answerButtons.Length; i++)
        {
            Button button = _answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}