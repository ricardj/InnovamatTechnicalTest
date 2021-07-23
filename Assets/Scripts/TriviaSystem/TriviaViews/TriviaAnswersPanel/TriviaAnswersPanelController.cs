using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TriviaAnswersPanelController : MonoBehaviour
{
    public List<TriviaButtonController> triviaButtons;


    [Header("Animation parameters")]
    public float delayBetweenButtonAnimations = 0.3f;

    private void Start()
    {
        HideTriviaButtons();
    }

    public void ShowAnswers(List<ITriviaAnswer> triviaAnswers)
    {
        PopulateButtons(triviaAnswers);
        ShowTriviaButtons();
    }

    public void PopulateButtons(List<ITriviaAnswer> triviaAnswers)
    {
        //We could check if trivia Answers and trivia buttons were same number. But for now we assume.

        for (int i = 0; i < triviaButtons.Count; i++)
        {
            triviaButtons[i].Configure(triviaAnswers[i]);
        }
    }

    public void ShowTriviaButtons()
    {
        StartCoroutine(ShowTriviaButtonsSequence());
    }

    public IEnumerator ShowTriviaButtonsSequence()
    {
        for (int i = 0; i < triviaButtons.Count; i++)
        {
            triviaButtons[i].Show();
            yield return new WaitForSeconds(delayBetweenButtonAnimations);
        }
    }

    public void HideTriviaButtons()
    {
        StartCoroutine(HideTriviaButtonsSequence());
    }

    public IEnumerator HideTriviaButtonsSequence()
    {
        for (int i = 0; i < triviaButtons.Count; i++)
        {
            triviaButtons[i].Hide();
            yield return new WaitForSeconds(delayBetweenButtonAnimations);
        }
    }
}
