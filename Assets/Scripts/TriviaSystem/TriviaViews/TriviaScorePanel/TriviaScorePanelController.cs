using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaScorePanelController : MonoBehaviour
{
    public Text correctAnswersText;
    public Text wrongAnswersText;

    public TriviaManager triviaManager;

    int correctAnswersCounter = 0;
    int wrongAnswersCounter = 0;

    public Transform showPositionPlaceholder;
    public Transform hidePositionPlaceholder;


    private void Start()
    {
        triviaManager.OnCorrectAnswer.AddListener(OnCorrectAnswer);
        triviaManager.OnWrongAnswer.AddListener(OnWrongAnswer);
        UpdateWrongText();
        UpdateCorrectText();
        HideFast();
        GameManager.get.OnGameStart.AddListener(() => Show());
    }


    public void OnCorrectAnswer()
    {
        correctAnswersCounter++;
        UpdateCorrectText();
    }

    private void UpdateCorrectText()
    {
        correctAnswersText.text = "ACIERTOS " + correctAnswersCounter.ToString();
    }

    public void OnWrongAnswer()
    {
        wrongAnswersCounter++;
        UpdateWrongText();
    }

    private void UpdateWrongText()
    {
        wrongAnswersText.text = "FALLOS " + wrongAnswersCounter.ToString();
    }

    public void Hide()
    {
        transform.MoveTo(hidePositionPlaceholder, 0.3f);
    }
    public void HideFast()
    {
        transform.position = hidePositionPlaceholder.position;
    }

    public void Show()
    {
        transform.MoveTo(showPositionPlaceholder, 1f);
    }
}
