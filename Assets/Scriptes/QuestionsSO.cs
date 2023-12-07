using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]

public class QuestionsSO : ScriptableObject
{
    [SerializeField] private string question = "Enter new question text here";


}
