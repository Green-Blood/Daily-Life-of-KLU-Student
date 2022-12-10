using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Create QuestionSettings", fileName = "QuestionSettings", order = 0)]
public class QuestionSettings : ScriptableObject
{
    public Question[] questions;
}
[Serializable]
public class Question
{
    public string questionName;
    public string[] questionVariant;
    public int rightAnswer;

} 