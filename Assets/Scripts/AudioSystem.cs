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

    [SerializeField] private float fadeSpeed = 1f;
    
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
        if(musicAudioSource.clip == exploreLoop50) return;
        musicAudioSource.DOFade(0, fadeSpeed).OnComplete(() =>
        {
            musicAudioSource.clip = exploreLoop50;
            musicAudioSource.Play();
            musicAudioSource.DOFade(1, fadeSpeed);
        });
    }
    public void StartExplore()
    {
        if(musicAudioSource.clip == exploreLoop) return;
        musicAudioSource.DOFade(0, fadeSpeed).OnComplete(() =>
        {
            musicAudioSource.clip = exploreLoop;
            musicAudioSource.Play();
            musicAudioSource.DOFade(1, fadeSpeed);
        });
    }
    public void StartBoss()
    {
        if(bossLoop == null) return;
        if(musicAudioSource.clip == bossLoop) return;
        musicAudioSource.DOFade(0, fadeSpeed).OnComplete(() =>
        {
            musicAudioSource.clip = bossLoop;
            musicAudioSource.Play();
            musicAudioSource.DOFade(1, fadeSpeed);
        });
    }
}