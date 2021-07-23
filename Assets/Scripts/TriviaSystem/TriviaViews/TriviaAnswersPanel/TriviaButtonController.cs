using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class TriviaButtonEvent : UnityEvent<TriviaButtonController> { };
public class TriviaButtonController : MonoBehaviour
{

    public Transform hidePositionPlaceholder;
    public Transform showPositionPlaceholder;

    public Text answerText;
    public Button button;
    public Image buttonImage;

    public TriviaButtonEvent OnButtonClicked;

    //Animation parameters
    float lerpFactor = 0.01f;

    private void Start()
    {
        button.onClick.AddListener(() => OnButtonClicked.Invoke(this));
    }

    public void Configure(ITriviaAnswer triviaAnswers)
    {
        answerText.text = triviaAnswers.GetAnswerText();
    }

    public void Hide()
    {
        transform.MoveTo(hidePositionPlaceholder,lerpFactor);
    }

    public void HideFast()
    {
        transform.position = hidePositionPlaceholder.transform.position;
    }

    public void Show()
    {
        transform.MoveTo(showPositionPlaceholder, lerpFactor);
    }

    public void WrongFeedback()
    {
        buttonImage.color = Color.red;
    }

    public void RightFeedback()
    {
        buttonImage.color = Color.green;
    }
}


