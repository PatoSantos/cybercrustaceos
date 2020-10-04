using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpForce = 5.0f;
    public bool isGrounded = false;
    float direction = 1.0f;

    Rigidbody2D rigidbody2d;
    Animator animator;

    public GameObject possessionObj;
    private Possession possession;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        possession = possessionObj.GetComponent<Possession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!possession.mainChar)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0.2f)
            {
                direction = 1.0f;
                animator.SetFloat("Direction", direction);
                animator.SetFloat("Speed", 1.0f);
            }
            else if (horizontal < -0.2)
            {
                direction = -1.0f;
                animator.SetFloat("Direction", direction);
                animator.SetFloat("Speed", 1.0f);
            }
            else if (horizontal > -0.2 && horizontal < 0.2)
            {
                animator.SetFloat("Direction", direction);
                animator.SetFloat("Speed", 0.0f);
            }

            Jump();


            Vector3 move = new Vector3(horizontal, 0f, 0f);

            transform.position += move * speed * Time.deltaTime;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
