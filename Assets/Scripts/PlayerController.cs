using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    float speed = 5.0f;
    float jumpForce = 300.0f;
    bool jump = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.speed = 1;
            animator.SetFloat("x", 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.speed = 1;
            animator.SetFloat("x", 1);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            animator.speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            jump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
    }
}
