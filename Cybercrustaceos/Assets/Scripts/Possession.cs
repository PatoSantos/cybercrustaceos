using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
    // Marco = true, Bug = false
    public bool mainChar = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainChar && Input.GetButtonDown("Fire1"))
        {
            mainChar = false;
        } else if (!mainChar && Input.GetButtonDown("Fire1"))
        {
            mainChar = true;
        }
    }
}
