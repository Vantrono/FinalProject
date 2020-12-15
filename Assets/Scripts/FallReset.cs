using UnityEngine;
using System.Collections;

public class FallReset : MonoBehaviour
{
    public float threshold;

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
            transform.position = new Vector3(15, 1, 37);
    }
}