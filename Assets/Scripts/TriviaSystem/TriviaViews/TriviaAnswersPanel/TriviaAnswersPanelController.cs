using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TriviaAnswersPanelController : MonoBehaviour
{
    public TriviaPanelController triviaPanelController;
    public List<TriviaButtonController> triviaButtons;

    List<ITriviaAnswer> triviaAnswers;

    [Header("Animation parameters")]
    public float delayBetweenButtonAnimations = 0.3f;

    //Flag values
    bool answersPhaseFinished = false;
    int remainingAnswerButtons = 3;

    private void Start()
    {
        HideButtonsFast();
        triviaButtons.ForEach(triviaButton => triviaButton.OnButtonClickedEvent.AddListener(OnTriviaButtonClicked));
    }

    public void ShowAnswers(List<ITriviaAnswer> triviaAnswers)
    {
        InitializeFlagValues();

        this.triviaAnswers = triviaAnswers;

        PopulateButtons(triviaAnswers);
        ShowTriviaButtons();
    }

    public void InitializeFlagValues()
    {
        remainingAnswerButtons = triviaButtons.Count;
        answersPhaseFinished = false;
    }

    public void PopulateButtons(List<ITriviaAnswer> triviaAnswers)
    {
        //We could check if trivia Answers and trivia buttons were same number. But for now we assume.

        for (int i = 0; i < triviaButtons.Count; i++)
        {

            triviaButtons[i].Configure(triviaAnswers[i]);
        }
    }

    public void OnTriviaButtonClicked(TriviaButtonController triviaButtonController)
    {
        bool isCorrect = triviaPanelController.IsCorrectAnswer(triviaAnswers[triviaButtons.IndexOf(triviaButtonController)]);
        if (isCorrect)
        {
            StartCoroutine(CorrectButtonSequence(triviaButtonController));
        }
        else
        {
            StartCoroutine(WrongAnswerButtonSequence(triviaButtonController));
        }
    }


    public IEnumerator CorrectButtonSequence(TriviaButtonController triviaButtonController)
    {
        triviaButtonController.RightFeedback();
        BlockButtons();
        yield return new WaitForSeconds(1f);
        HideTriviaButtonsFast();
        FinishAnswersPhase();
    }

    public IEnumerator WrongAnswerButtonSequence(TriviaButtonController triviaButtonController)
    {
        triviaButtonController.WrongFeedback();
        if (remainingAnswerButtons > 2)
        {
            yield return new WaitForSeconds(0.3f);
            triviaButtonController.Hide();
        }
        else
        {
            TriviaButtonController correctTriviaButton = triviaButtons.Find(triviaButton => !triviaButton.IsButtonClicked);
            BlockButtons();
            correctTriviaButton.RightFeedback();
            yield return new WaitForSeconds(0.7f);
            HideTriviaButtonsFast();
            FinishAnswersPhase();
        }

        remainingAnswerButtons--;
    }

    public void BlockButtons()
    {
        triviaButtons.ForEach(triviaButton => triviaButton.BlockButton());

    }

    public void FinishAnswersPhase()
    {
        answersPhaseFinished = true;

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

    public void HideTriviaButtonsFast()
    {
        for (int i = 0; i < triviaButtons.Count; i++)
        {
            triviaButtons[i].Hide();
        }
    }

    public IEnumerator HideTriviaButtonsSequence()
    {
        for (int i = 0; i < triviaButtons.Count; i++)
        {
            triviaButtons[i].Hide();
            yield return new WaitForSeconds(delayBetweenButtonAnimations);
        }
    }

    public void HideButtonsFast()
    {
        triviaButtons.ForEach(triviaButton => triviaButton.HideFast());
    }

    public bool IsAnswerPhaseFinished()
    {
        return answersPhaseFinished;
    }
}
