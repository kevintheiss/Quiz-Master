using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion = false;
    public float fillFraction;

    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0f;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (isAnsweringQuestion)
        {
            if(timerValue > 0f)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                timerValue = timeToCompleteQuestion;
                isAnsweringQuestion = false;
            }
        }
        else
        {
            if (timerValue > 0f)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToShowCorrectAnswer;
                loadNextQuestion = true;
            }
        }
        Debug.Log(isAnsweringQuestion + ":" + timerValue + "=" + fillFraction);
    }
}
