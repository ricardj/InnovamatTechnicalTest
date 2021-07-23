using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriviaButtonController : MonoBehaviour
{

    public Transform hidePositionPlaceholder;
    public Transform showPositionPlaceholder;

    public Text answerText;
    

    //Animation parameters
    float lerpFactor = 0.2f;

    public void Configure(ITriviaAnswer triviaAnswers)
    {
        answerText.text = triviaAnswers.GetAnswerText();
    }

    public void Hide()
    {
        transform.MoveTo(hidePositionPlaceholder,lerpFactor);
    }

    public void Show()
    {
        transform.MoveTo(showPositionPlaceholder, lerpFactor);
    }
}


