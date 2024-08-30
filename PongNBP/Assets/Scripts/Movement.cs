using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 30f;

    private void FixedUpdate()
    {
        float input = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().velocity = 
            new Vector2 (0, input) * speed;
    }
}
