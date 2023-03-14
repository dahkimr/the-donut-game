using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager sfxManagerInstance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip SpeedUpAudioClip;
    [SerializeField] private AudioClip TheDonutGameClip;

    private float startPitch = 0.95f;
    private float pitchToInc = 0.05f;
    
    private void Awake() {
        if (sfxManagerInstance != null && sfxManagerInstance != this) {
            Destroy(this.gameObject);
            return;
        }

        audioSource.pitch = startPitch;
        sfxManagerInstance = this;
        DontDestroyOnLoad(this);
    }

    public void Stop() {
        audioSource.Stop();
    }

    private void Play() {
        audioSource.Play();
    }

    public void PlaySpeedUp() {
        audioSource.pitch += pitchToInc;
        audioSource.clip = SpeedUpAudioClip;
        Play();
    }

    public void PlayTheDonutGame() {
        audioSource.clip = TheDonutGameClip;
        Play();
    }
}
