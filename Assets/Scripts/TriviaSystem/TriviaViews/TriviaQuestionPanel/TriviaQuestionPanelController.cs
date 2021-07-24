using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaQuestionPanelController : MonoBehaviour
{
    public Transform leftPlaceholder;
    public Transform centerPlaceholder;
    public Transform rightPlaceholder;

    public Text questionText;
    public CanvasGroup canvasGroup;

    public float duration = 0.5f;

    public void Start()
    {
        HideQuestionFast();
    }

    public void ShowQuestion(ITriviaQuestion triviaQuestion)
    {
        questionText.text = triviaQuestion.GetQuestionText();

        transform.position = rightPlaceholder.transform.position;
        transform.MoveTo(centerPlaceholder, duration);
        
        canvasGroup.alpha = 0;
        canvasGroup.FadeTo(1, duration);
    }

    public void HideQuestion()
    {
        canvasGroup.alpha = 1;
        canvasGroup.FadeTo(0, duration);
        transform.MoveTo(leftPlaceholder, duration);
    }

    public void HideQuestionFast()
    {
        transform.position = rightPlaceholder.transform.position;
        canvasGroup.alpha = 0;
    }

}
