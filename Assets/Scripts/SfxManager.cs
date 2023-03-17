using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager sfxManagerInstance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource speedUpAudioSource;
    [SerializeField] private AudioClip[] ratingClips = new AudioClip[4];

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
        speedUpAudioSource.pitch += pitchToInc;
        speedUpAudioSource.Play();
    }

    public void PlayRating(string text) {
        switch (text)
        {
            case "really?":
                audioSource.clip = ratingClips[0];
                break;
            case "nice.":
                audioSource.clip = ratingClips[1];
                break;
            case "great!":
                audioSource.clip = ratingClips[2];
                break;
            case "amazing!":
                audioSource.clip = ratingClips[3];
                break;
            default:
                break;
        }
        Play();
    }
}
