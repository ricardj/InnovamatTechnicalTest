using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriviaAnswer", menuName = "Trivia System / New Answer", order = 2)]
public class TriviaAnswerSO : ScriptableObject, ITriviaAnswer
{
    public string answerText;
    public GameObject answerPrefab;


    GameObject ITriviaAnswer.GetAnswerPrefab()
    {
        return answerPrefab;
    }

    string ITriviaAnswer.GetAnswerText()
    {
        return answerText;
    }

    
}


