using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    public AudioClip selectStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AudioSourceController.instance.PlayOneShot(selectStage);
            Invoke("SceneLoad", 1.0f);
        }
    }

    void SceneLoad()
    {
        SceneManager.LoadScene("Load");
    }
}
