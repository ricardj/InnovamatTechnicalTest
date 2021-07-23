using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "TriviaQuestion", menuName = "Trivia System / New Question", order = 1)]
public class TriviaQuestionSO : ScriptableObject, ITriviaQuestion
{
    [TextArea]
    public string questionText;
    public List<TriviaAnswerSO> rightAnswersPool;
    public List<TriviaAnswerSO> wrongAnswersPool;

    List<ITriviaAnswer> ITriviaQuestion.GetAnswers()
    {
        List<ITriviaAnswer> answersBundle = new List<ITriviaAnswer>();

        AddRightAnswer(answersBundle);
        AddTwoDifferentWrongAnswers(answersBundle);

        answersBundle = RandomizeAnswers(answersBundle);

        return answersBundle;
    }

    public bool IsCorrectAnswer(TriviaAnswerSO triviaAnswer)
    {
        bool isCorrect = false;

        if (rightAnswersPool.Contains(triviaAnswer))
            isCorrect = true;

        return isCorrect;
    }

    private static List<ITriviaAnswer> RandomizeAnswers(List<ITriviaAnswer> answersBundle)
    {
        System.Random rng = new System.Random();

        answersBundle = answersBundle.OrderBy(a => rng.Next()).ToList();
        return answersBundle;
    }

    private void AddRightAnswer(List<ITriviaAnswer> answersBundle)
    {
        answersBundle.Add(PickRandomItem(rightAnswersPool));
    }


    private void AddTwoDifferentWrongAnswers(List<ITriviaAnswer> answersBundle)
    {
        List<TriviaAnswerSO> auxiliarWrongAnswerPool = new List<TriviaAnswerSO>(wrongAnswersPool);
        TriviaAnswerSO wrongAnswer1 = PickRandomItem(auxiliarWrongAnswerPool);
        answersBundle.Add(wrongAnswer1);

        auxiliarWrongAnswerPool.Remove(wrongAnswer1);
        TriviaAnswerSO wrongAnswer2 = PickRandomItem(auxiliarWrongAnswerPool);
        answersBundle.Add(wrongAnswer2);
    }

    public TriviaAnswerSO PickRandomItem(List<TriviaAnswerSO> answersList)
    {
        if (answersList.Count == 0)
            return null;
        return answersList[UnityEngine.Random.Range(0, answersList.Count)];
    }

    string ITriviaQuestion.GetQuestionText()
    {
        return questionText;
    }


}
