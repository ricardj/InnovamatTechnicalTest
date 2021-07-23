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

    public float lerpFactor = 0.5f;

    public void Start()
    {
        transform.position = rightPlaceholder.transform.position;
    }

    public void ShowQuestion(ITriviaQuestion triviaQuestion)
    {
        questionText.text = triviaQuestion.GetQuestionText();

        transform.position = rightPlaceholder.transform.position;
        transform.MoveTo(centerPlaceholder, lerpFactor);

    }

    public void HideQuestion()
    {
        transform.MoveTo(leftPlaceholder, lerpFactor);
    }

}
