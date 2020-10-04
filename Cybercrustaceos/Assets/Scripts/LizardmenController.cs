using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardmenController : MonoBehaviour
{
    public float movement = 1.0f;
    float speed;
    bool cycle = true;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        speed = movement;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > movement * -1 && cycle)
        {
            move = new Vector3(speed, 0.0f, 0.0f);
            transform.position += move * Time.deltaTime;
            speed -= Time.deltaTime;
            Debug.Log(speed);
        }
        else if (speed < movement)
        {
            cycle = false;
            move = new Vector3(speed, 0.0f, 0.0f);
            transform.position += move * Time.deltaTime;
            speed += Time.deltaTime;
            Debug.Log(speed);
        }
        else
        {
            cycle = true;
        }
    }
}
