using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriviaPanelController : MonoBehaviour
{
    public TriviaManager triviaManager;

    public UnityEvent OnAnswerSelected;

    [Header("GUI references")]
    public TriviaQuestionPanelController questionPanel;
    public TriviaAnswersPanelController answersPanel;


    bool questionAnsweredCorrectly;

    public void ShowTriviaQuestion(ITriviaQuestion triviaQuestion)
    {
        StartCoroutine(ShowTriviaQuestionSequence(triviaQuestion));
    }

    public IEnumerator ShowTriviaQuestionSequence(ITriviaQuestion triviaQuestion)
    {
        questionPanel.ShowQuestion(triviaQuestion);

        yield return new WaitForSeconds(2);     //We wait for the apparition of the question        
        yield return new WaitForSeconds(2);     //We wait 2 extra seconds for player to read the question

        questionPanel.HideQuestion();

        yield return new WaitForSeconds(2);     //We wait for the question to vanish


        answersPanel.ShowAnswers(triviaQuestion.GetAnswers());

        questionAnsweredCorrectly = false;
        yield return new WaitUntil(() => questionAnsweredCorrectly);

        answersPanel.HideTriviaButtons();
    }

    public bool IsCorrectAnswer(ITriviaAnswer triviaAnswer)
    {
        bool isCorrect = triviaManager.IsCorrectAnswer(triviaAnswer);
        if(isCorrect)
        {
            questionAnsweredCorrectly = true;
        }

        return isCorrect;

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

    TriviaAnswerSO GetTriviaAnswerSO();
}
