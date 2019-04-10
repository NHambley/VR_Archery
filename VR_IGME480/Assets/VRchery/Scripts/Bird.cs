using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector3 position;

    public float turnSpeed = 2.0f;
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        position += this.transform.forward * speed;
        this.transform.Rotate(Vector3.up, turnSpeed);

        this.transform.position = position;
    }
}
