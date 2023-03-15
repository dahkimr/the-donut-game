using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayHomeScreenAudio());
    }

    IEnumerator PlayHomeScreenAudio() {
        yield return new WaitForSeconds(0.25f);
        audioSource.Play();
    }
}
