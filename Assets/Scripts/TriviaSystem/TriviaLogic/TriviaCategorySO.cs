using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriviaCategory", menuName = "Trivia System / New Category", order = 0)]

public class TriviaCategorySO : ScriptableObject
{
    [TextArea]
    public string categoryDescription;
    public List<TriviaQuestionSO> questionPool;
    
}
