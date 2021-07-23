using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriviaQuestion", menuName = "Trivia System / New Question", order =1)]
public class TriviaQuestionSO : ScriptableObject
{
    [TextArea]
    public string questionText;
    public List<TriviaAnswerSO> rightAnswersPool;
    public List<TriviaQuestionSO> wrongAnswersPool;

}
