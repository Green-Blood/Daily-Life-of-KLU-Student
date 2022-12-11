using DG.Tweening;
using ExtentionMethods;
using Sirenix.OdinInspector;
using UnityEngine;

public class AudioSystem : SingletonClass<AudioSystem>
{
    [Title("Ambient")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip bossAmbient;
    [SerializeField] private AudioClip corridorAmbient;
    [Title("Music")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioClip exploreLoop;
    [SerializeField] private AudioClip exploreLoop50;
    [SerializeField] private AudioClip bossLoop;
    public void StartBossAmbient()
    {
        audioSource.clip = bossAmbient; 
        audioSource.Play();
    }
    public void StartCorridorAmbient()
    {
        audioSource.clip = corridorAmbient; 
        audioSource.Play();
    }

    public void StartExplore50()
    {
        musicAudioSource.DOFade(0, 0.5f).OnComplete(() =>
        {
            musicAudioSource.clip = exploreLoop50;
            musicAudioSource.DOFade(1, 0.5f);
        });
    }
    public void StartExplore()
    {
        musicAudioSource.DOFade(0, 0.5f).OnComplete(() =>
        {
            musicAudioSource.clip = exploreLoop;
            musicAudioSource.DOFade(1, 0.5f);
        });
    }
    public void StartBoss()
    {
        musicAudioSource.DOFade(0, 0.5f).OnComplete(() =>
        {
            musicAudioSource.clip = bossLoop;
            musicAudioSource.DOFade(1, 0.5f);
        });
    }
}