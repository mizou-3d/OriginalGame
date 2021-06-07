using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class AudioSourceController : MonoBehaviour
{
    private static AudioSourceController m_instance;
    public static AudioSourceController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<AudioSourceController>();

                if (m_instance == null)
                {
                    m_instance = new GameObject("AudioSourceController").AddComponent<AudioSourceController>();
                }
            }
            return m_instance;
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
