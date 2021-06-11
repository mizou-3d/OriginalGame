using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterEasyStage : MonoBehaviour
{
    public AudioClip selectStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSourceController.instance.PlayOneShot(selectStage);
            Invoke("EasyStage", 1.0f);
        }
    }

    void EasyStage()
    {
        SceneManager.LoadScene("World_1");
    }
}
