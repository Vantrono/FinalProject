using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour

// Got help from this BoardtoBits Games on youtube for this mechanic 
// https://www.youtube.com/watch?v=7KiK0Aqtmzc
// This script is used to make it less floaty feeling by using Physics.
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
         rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) 
        {
         rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
    }
}
