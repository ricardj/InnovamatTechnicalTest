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
    public CanvasGroup canvasGroup;

    public TriviaButtonEvent OnButtonClickedEvent;


    //Animation parameters
    public float duration = 0.3f;
    public Color originalButtonImageColor;

    //Flag values
    bool buttonClicked = false;
    public bool IsButtonClicked { get => buttonClicked; set => buttonClicked = value; }

    private void Start()
    {
        originalButtonImageColor = buttonImage.color;
        button.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        if (!IsButtonClicked)
        {
            IsButtonClicked = true;
            OnButtonClickedEvent.Invoke(this);
        }
    }

    public void Configure(ITriviaAnswer triviaAnswers)
    {
        answerText.text = triviaAnswers.GetAnswerText();
        RestartButtonColor();
        IsButtonClicked = false;

    }

    public void Hide()
    {
        transform.MoveTo(hidePositionPlaceholder, duration);
        canvasGroup.alpha = 1;
        canvasGroup.FadeTo(0, 0.3f);
    }

    public void HideFast()
    {
        transform.position = hidePositionPlaceholder.transform.position;
    }

    public void Show()
    {
        transform.MoveTo(showPositionPlaceholder, duration);
        canvasGroup.alpha = 0;
        canvasGroup.FadeTo(1, duration);
    }


    public void RestartButtonColor()
    {
        buttonImage.color = originalButtonImageColor;
    }


    public void WrongFeedback()
    {
        buttonImage.color = Color.red;
        transform.Shake(1f, 0.3f);
    }

    public void RightFeedback()
    {
        buttonImage.color = Color.green;
    }

    public void BlockButton()
    {
        IsButtonClicked = true;
    }
}


