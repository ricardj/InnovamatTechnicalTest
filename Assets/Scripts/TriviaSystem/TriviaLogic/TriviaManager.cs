using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriviaManager : MonoBehaviour
{
    public UnityEvent OnRightAnswer;
    public UnityEvent OnWrongAnswer;

    public TriviaCategorySO mainQuestionPool;

    public Queue<TriviaQuestionSO> currentQuestionsPool;

    public TriviaPanelController triviaPanelController;

    TriviaQuestionSO currentTriviaQuestion;

    public void Start()
    {
        currentQuestionsPool = new Queue<TriviaQuestionSO>();
        StartCoroutine(TriviaSequence());
    }

    public IEnumerator TriviaSequence()
    {
        while (true)
        {
            FillCurrentQuestions();
            while (currentQuestionsPool.Count > 0)
            {
                currentTriviaQuestion = currentQuestionsPool.Dequeue();
                yield return triviaPanelController.ShowTriviaQuestionSequence((ITriviaQuestion)currentTriviaQuestion);

            }
            yield return null;
        }
    }


    public void FillCurrentQuestions()
    {
        mainQuestionPool.questionPool.ForEach(question =>
        {
            currentQuestionsPool.Enqueue(question);
        });
    }

    public bool IsCorrectAnswer(ITriviaAnswer triviaAnswer)
    {
        return currentTriviaQuestion.IsCorrectAnswer(triviaAnswer.GetTriviaAnswerSO());
    }

}
