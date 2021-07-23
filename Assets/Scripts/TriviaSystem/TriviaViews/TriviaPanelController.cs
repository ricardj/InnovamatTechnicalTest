using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriviaPanelController : MonoBehaviour
{
    public UnityEvent OnAnswerSelected;

    public TriviaQuestionPanelController questionPanel;
    public TriviaAnswersPanelController answersPanel;

    

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

        bool questionAnsweredCorrectly = false;

        yield return new WaitUntil(() => questionAnsweredCorrectly);
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
