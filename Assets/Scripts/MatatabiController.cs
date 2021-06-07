using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatatabiController : MonoBehaviour
{
    public GameObject player;
    public AudioClip mataGet;

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
            AudioSourceController.instance.PlayOneShot(mataGet);
            PointController.instance.AddMata();
            PointController.instance.SetData();
            PointController.instance.LogData();
            Destroy(this.gameObject);
        }
    }
}
