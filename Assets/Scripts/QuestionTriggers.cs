using UnityEngine;

public class QuestionTriggers : MonoBehaviour
{
    [SerializeField] private QuestionTrigger[] questionTriggers;
    [SerializeField] private QuestionUI questionUI;
    [SerializeField] private QuestionSettings questionSettings;

    private int _currentQuestion;

    public void NextQuestion()
    {
        InitQuestionTriggers(questionSettings.questions[_currentQuestion]);
        _currentQuestion++;
        Debug.Log("Next question started " + _currentQuestion);
    }

    public void InitQuestionTriggers(Question currentQuestion)
    {
        ResetQuestionTriggers();
        questionUI.FadeInQuestionPanel(() =>
        {
            for (var index = 0; index < questionTriggers.Length; index++)
            {
                var questionTrigger = questionTriggers[index];
                if (currentQuestion.rightAnswer == index)
                {
                    questionTrigger.isCorrect = true;
                }
            }

            questionUI.InitQuestionVariants(currentQuestion.questionVariant);
            questionUI.InitQuestion(currentQuestion.questionName);
        });
    }

    private void ResetQuestionTriggers()
    {
        foreach (var questionTrigger in questionTriggers)
            questionTrigger.isCorrect = false;
    }
}