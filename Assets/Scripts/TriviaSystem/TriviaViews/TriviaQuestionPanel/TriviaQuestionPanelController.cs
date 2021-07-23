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

    public void ShowQuestion(ITriviaQuestion triviaQuestion)
    {
        questionText.text = triviaQuestion.GetQuestionText();

        transform.position = rightPlaceholder.transform.position;
        transform.MoveTo(centerPlaceholder, 0.2f);

    }

    public void HideQuestion()
    {
        transform.MoveTo(leftPlaceholder, 0.2f);
    }

}
