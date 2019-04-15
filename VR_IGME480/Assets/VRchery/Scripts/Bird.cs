using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector3 position;

    public float turnSpeed = 2.0f;
    public float speed = 0.05f;

    float baseHeight;
    float degree;

    public float degreesPerSecond = 180f;
    public float moveheight = 0.5f;

    public bool oscillate = false;

    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
        degree = 0.0f;
        baseHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        position += this.transform.forward * speed;
        this.transform.Rotate(Vector3.up, turnSpeed);

        if(oscillate)
            OscillateHeight();

        this.transform.position = position;
    }

    void OscillateHeight()
    {
        if(degree > 359.0f)
        {
            degree = 0f;
        }
        float siny = Mathf.Sin(degree) * moveheight;
        position.y = baseHeight + siny;

        degree += (degreesPerSecond / 60.0f) * Time.deltaTime;
    }
}
