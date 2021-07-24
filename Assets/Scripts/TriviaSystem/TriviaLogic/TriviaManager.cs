using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class TriviaManager : MonoBehaviour
{
    public UnityEvent OnCorrectAnswer;
    public UnityEvent OnWrongAnswer;

    public TriviaCategorySO mainQuestionPool;

    public Queue<TriviaQuestionSO> currentQuestionsPool;

    public TriviaPanelController triviaPanelController;

    TriviaQuestionSO currentTriviaQuestion;

    public void Start()
    {
        currentQuestionsPool = new Queue<TriviaQuestionSO>();

        GameManager.get.OnGameStart.AddListener(() =>
        {
            StartCoroutine(TriviaSequence());
        });

    }

    public IEnumerator TriviaSequence()
    {
        yield return new WaitForSeconds(0.3f); //Initial delay
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
        //We fill randomly the available questions
        System.Random rng = new System.Random();

        mainQuestionPool.questionPool.OrderBy(a => rng.Next()).ToList().ForEach(question =>
        {
            currentQuestionsPool.Enqueue(question);
        });
    }

    public bool IsCorrectAnswer(ITriviaAnswer triviaAnswer)
    {

        bool isCorrect = currentTriviaQuestion.IsCorrectAnswer(triviaAnswer.GetTriviaAnswerSO());

        if (isCorrect)
            OnCorrectAnswer.Invoke();
        else
            OnWrongAnswer.Invoke();


        return isCorrect;
    }

}
