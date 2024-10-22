using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float movespeed = 5;
    public readonly float deadzone = -30;

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * movespeed) * Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }
}
