using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MarcoController : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpForce = 5.0f;
    public bool isGrounded = false;
    float direction = 1.0f;

    Rigidbody2D rigidbody2d;
    public Collider2D standingCollider;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        standingCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
   
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Approximately(horizontal, 1.0f))
        {
            direction = 1.0f;
            animator.SetFloat("Direction", direction);
            animator.SetFloat("Speed", 1.0f);
        } else if (Mathf.Approximately(horizontal, -1.0f))
        {
            direction = -1.0f;
            animator.SetFloat("Direction", direction);
            animator.SetFloat("Speed", 1.0f);
        } else if (Mathf.Approximately(horizontal, 0.0f))
        {
            animator.SetFloat("Direction", direction);
            animator.SetFloat("Speed", 0.0f);
        }

        Jump(vertical);


        Vector3 move = new Vector3(horizontal, 0f, 0f);

        transform.position += move * speed * Time.deltaTime;
    }

    void Jump(float vertical)
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse); 
        }

        if (vertical < 0.0f && isGrounded)
        {
            animator.SetBool("Crouch", true);
            standingCollider.enabled = false;
        }
        else
        {
            animator.SetBool("Crouch", false);
            standingCollider.enabled = true;
        }
    }
}
