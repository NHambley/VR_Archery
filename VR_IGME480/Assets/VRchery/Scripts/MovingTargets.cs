using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargets : MonoBehaviour
{
    // an array of the different positions for the targets to move through
    public GameObject[] movePos;
    int step = 0;

    Vector3 position;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVec = (movePos[step].transform.position - position);
        moveVec.Normalize();
        moveVec *= (Time.deltaTime * speed);

        position += moveVec;
        transform.position = position;

        if(Vector3.Distance(transform.position, movePos[step].transform.position) < 0.5f)
        {
            step += 1;

            // make sure that step does not go outside the array bounds
            if(step == movePos.Length)
            {
                step = 0;
            }
        }
    }
}
