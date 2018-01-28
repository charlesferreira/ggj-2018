using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {

    AudioSource audioSource;

    public AudioClip intro;
    public AudioClip loop;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        audioSource.clip = intro;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.clip = loop;
        audioSource.Play();
    }
}
