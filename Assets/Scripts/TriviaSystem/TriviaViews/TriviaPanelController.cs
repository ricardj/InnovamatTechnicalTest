using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriviaPanelController : MonoBehaviour
{
    public UnityEvent OnAnswerSelected;

    public TriviaQuestionPanelController questionPanel;
    public TriviaAnswersPanelController answersPanel;

    [Header("Animation parameters")]
    public float timeBetweenQuestionAndAnswers = 3f;

    public void ShowTriviaQuestion(ITriviaQuestion triviaQuestion)
    {
        StartCoroutine(ShowTriviaQuestionSequence(triviaQuestion));
    }

    public IEnumerator ShowTriviaQuestionSequence(ITriviaQuestion triviaQuestion)
    {
        questionPanel.ShowQuestion(triviaQuestion);
        yield return new WaitForSeconds(timeBetweenQuestionAndAnswers);
        answersPanel.ShowAnswers(triviaQuestion.GetAnswers());
    }

    
}

public interface ITriviaQuestion
{
    string GetQuestionText();
    List<ITriviaAnswer> GetAnswers();
}

public interface ITriviaAnswer
{
    string GetAnswerText();
    GameObject GetAnswerPrefab();
}
