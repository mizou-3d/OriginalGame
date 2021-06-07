using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(PlayerController), typeof(AudioSource))]
public class Base : MonoBehaviour
{
    [SerializeField]
    private AudioClip jumpVoice;
    [SerializeField]
    private AudioClip timeOverVoice;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayVoice(AudioClip voice)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(voice);
    }

    void Jump()
    {
        PlayVoice(jumpVoice);
    }
    void TimeOver()
    {
        PlayVoice(timeOverVoice);
    }
}
