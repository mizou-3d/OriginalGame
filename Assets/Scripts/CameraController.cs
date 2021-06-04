using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform catPlayer;
    public Transform stopPosition;

    private Camera m_camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        m_camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var right = m_camera.ViewportToWorldPoint(Vector2.right);
        var center = m_camera.ViewportToWorldPoint(Vector2.one * 0.5f);

        if (center.x < catPlayer.position.x)
        {
            var pos = m_camera.transform.position;

            if (Mathf.Abs(pos.x - catPlayer.position.x) >= 0.0000001f)
            {
                m_camera.transform.position = new Vector3(catPlayer.position.x, pos.y, pos.z);
            }
        }
        if (stopPosition.position.x - right.x < 0)
        {
            enabled = false;
        }
    }
}
