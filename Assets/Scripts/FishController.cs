using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public AudioClip fishGet;

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
            AudioSourceController.instance.PlayOneShot(fishGet);
            PointController.instance.AddFish();
            PointController.instance.SetData();
            PointController.instance.LogData();
            Destroy(this.gameObject);
        }
    }
}
