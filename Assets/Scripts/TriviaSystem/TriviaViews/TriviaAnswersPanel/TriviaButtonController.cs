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
    public Shadow shadow;
    public CanvasGroup canvasGroup;

    public TriviaButtonEvent OnButtonClickedEvent;


    //Animation parameters
    public float duration = 0.3f;
    public Color originalButtonImageColor;
    public Color originalShadowColor;

    //Flag values
    bool buttonClicked = false;
    public bool IsButtonClicked { get => buttonClicked; set => buttonClicked = value; }

    private void Start()
    {
        originalButtonImageColor = buttonImage.color;
        originalShadowColor = shadow.effectColor;
        button.onClick.AddListener(OnButtonClicked);
    }

    public void OnButtonClicked()
    {
        if (!IsButtonClicked)
        {
            OnButtonClickedEvent.Invoke(this);
            BlockButton();
        }
    }

    public void Configure(ITriviaAnswer triviaAnswers)
    {
        answerText.text = triviaAnswers.GetAnswerText();
        RestartButtonColor();
        UnblockButton();
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
        shadow.effectColor = originalShadowColor;
    }


    public void WrongFeedback()
    {
        buttonImage.color = Color.red;
        shadow.effectColor = Color.red;
        transform.Shake(3f, 0.3f);
    }

    public void RightFeedback()
    {
        shadow.effectColor = Color.green;
        buttonImage.color = Color.green;
    }

    public void UnblockButton()
    {
        button.enabled = true;
        IsButtonClicked = false;
    }

    public void BlockButton()
    {
        button.enabled = false;
        IsButtonClicked = true;
    }
}


