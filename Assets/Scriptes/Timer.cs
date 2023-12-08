using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeToCompleteQuestion = 20;
    [SerializeField] private float _timeToShowCorrectAnswer = 5;
    [SerializeField] private bool _isAnsweringQuestion = false;

    private float _timerValue;

    public float FillFraction { get; private set; }
    public bool LoadNextQuestion { get; set; }

    public bool GetIsAnsweringQuestion()
    {
        return _isAnsweringQuestion;
    }

    public void CancelTimer()
    {
        _timerValue = 0;
    }

    private void Update()
    {
        UpdatteTimer();
    }

    private void UpdatteTimer()
    {
        _timerValue -= Time.deltaTime;

        if (_isAnsweringQuestion)
        {
            if (_timerValue > 0)
            {
                FillFraction = _timerValue / _timeToCompleteQuestion;
            }
            else
            {
                _isAnsweringQuestion = false;
                _timerValue = _timeToShowCorrectAnswer;
            }
        }
        else
        {
            if (_timerValue > 0)
            {
                FillFraction = _timerValue / _timeToShowCorrectAnswer;
            }
            else
            {
                _isAnsweringQuestion = true;
                _timerValue = _timeToCompleteQuestion;
                LoadNextQuestion = true;
            }
        }

        if (_timerValue <= 0)
        {
            _timerValue = _timeToCompleteQuestion;
        }

        Debug.Log($"{_isAnsweringQuestion}: {_timerValue} = {FillFraction}");
    }
}