using System;
using Core;
using Dossamer.Dialogue;
using Dossamer.Dialogue.Schema;
using MoreMountains.Feedbacks;
using UnityEngine;

public class QuestionTriggers : MonoBehaviour
{
    [SerializeField] private QuestionTrigger[] questionTriggers;
    [SerializeField] private QuestionUI questionUI;
    [SerializeField] private QuestionSettings questionSettings;
    [SerializeField] private Cutscene tomEndCutscene;
    [SerializeField] private MMF_Player correctFeedback;
    [SerializeField] private MMF_Player inCorrectFeedback;
    [SerializeField] private MMF_Player winFeedback;
    [SerializeField] private MMF_Player startFeedback;
    

    private int _currentQuestion;
    public Action OnQuestionsFinished;
    private StateMachine _stateMachine;
    private bool _isQuestionsFinished;

    private void Awake()
    {
        foreach (var questionTrigger in questionTriggers)
        {
            questionTrigger.OnCorrectQuestionTriggered += OnCorrectQuestionTriggered;
            questionTrigger.OnInCorrectQuestionTriggered += OnInCorrectQuestionTriggered;
        }

        OnQuestionsFinished += FinishQuestions;
    }

    public void PlayStartFeedbacks() => startFeedback.PlayFeedbacks();

    private void OnInCorrectQuestionTriggered()
    {
        inCorrectFeedback.PlayFeedbacks();
    }

    public void Construct(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        stateMachine.OnStateChange += OnStateChange;
    }

    private void OnStateChange(State state)
    {
        if (state == State.MathiasSecret)
        {
            gameObject.SetActive(false);
            questionUI.FadeOutQuestionPanel(() =>
            {
                _stateMachine.Enter(State.GameEnd);
            });
            
        }
    }

    private void FinishQuestions()
    {
        gameObject.SetActive(false);
        questionUI.FadeOutQuestionPanel(null);
        DialogueManager.Instance.StartNewDialogue(tomEndCutscene);
        winFeedback.PlayFeedbacks();
        AudioSystem.Instance.StartCorridorAmbient();
    }

    private void OnCorrectQuestionTriggered()
    {
        NextQuestion();
        correctFeedback.PlayFeedbacks();
    }

    public void NextQuestion()
    {
        if (!_isQuestionsFinished)
        {
            InitQuestionTriggers(questionSettings.questions[_currentQuestion]);
            _currentQuestion++;
            Debug.Log("Next question started " + _currentQuestion);
        }
        else
        {
            OnQuestionsFinished?.Invoke();
        }

        if (_currentQuestion >= questionSettings.questions.Length)
        {
            _isQuestionsFinished = true;
        }
    }

    public void InitQuestionTriggers(Question currentQuestion)
    {
        ResetQuestionTriggers();
        questionUI.FadeInQuestionPanel(() =>
        {
            SetRightAnswer(currentQuestion);
            if (IfNoRightAnswer(currentQuestion)) SetAllAnswersCorrect();

            questionUI.InitQuestionVariants(currentQuestion.questionVariant);
            questionUI.InitQuestion(currentQuestion.questionName);
        });
    }

    private void SetRightAnswer(Question currentQuestion)
    {
        for (var index = 0; index < questionTriggers.Length; index++)
        {
            var questionTrigger = questionTriggers[index];
            if (currentQuestion.rightAnswer == index)
            {
                questionTrigger.isCorrect = true;
            }
        }
    }

    private static bool IfNoRightAnswer(Question currentQuestion)
    {
        return currentQuestion.rightAnswer == -1;
    }

    private void SetAllAnswersCorrect()
    {
        foreach (var questionTrigger in questionTriggers)
        {
            questionTrigger.isCorrect = true;
        }
    }

    private void ResetQuestionTriggers()
    {
        foreach (var questionTrigger in questionTriggers)
            questionTrigger.isCorrect = false;
    }
}