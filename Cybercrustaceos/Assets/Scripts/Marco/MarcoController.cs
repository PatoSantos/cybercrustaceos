using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MarcoController : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpForce = 5.0f;
    public bool isGrounded = false;

    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, 0f);

        transform.position += move * speed * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody2d.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse); 
        }
    }
}
