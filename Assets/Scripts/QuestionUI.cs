using System;
using DG.Tweening;
using Dossamer.Dialogue;
using TMPro;
using UnityEngine;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] questionVariants;
    [SerializeField] private TextMeshProUGUI currentQuestion;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeOutDuration = 1f;
    [SerializeField] private TextIterator iterator;

    public void InitQuestionVariants(string[] variants)
    {
        for (var index = 0; index < questionVariants.Length; index++)
        {
            var questionVariant = questionVariants[index];
            questionVariant.text = variants[index];
        }
    }

    public void InitQuestion(string question)
    {
        currentQuestion.text = question;
        iterator.TriggerNewText(question);
    }


    public void FadeOutQuestionPanel(Action onFadeOutComplete)
    {
        canvasGroup.DOFade(0, fadeOutDuration).OnComplete((() =>
        {
            gameObject.SetActive(false);
            onFadeOutComplete?.Invoke();
        }));
    }

    public void FadeInQuestionPanel(Action onFadeInComplete)
    {
        gameObject.SetActive(true);
        canvasGroup.DOFade(0.7f, fadeOutDuration).OnComplete((() => { onFadeInComplete?.Invoke();}));
    }
}