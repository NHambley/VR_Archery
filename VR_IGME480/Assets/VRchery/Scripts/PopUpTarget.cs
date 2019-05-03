using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTarget : MonoBehaviour
{
    public float timerH;// how long the target stays behind cover
    public float timerO;// how long the target stays out in open view

    float timer;
    bool revealed = false;// is the target showing itself or not
    bool moving = false;
    Vector3 position;

    float speed = 5f;
    public Transform revealedPos; // the position in world space the target will move to to be revealed
    public Transform hiddenPos;// where the target hides
    Transform destination;// which transform is the target heading towards

    AudioSource whoosh;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        timer = timerH;
        whoosh = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the target is revealed or not, reduce a specific timer
        if(!revealed && !moving)
        {
            timer -= Time.deltaTime;
            // if it is done hiding, move it out of cover
            if(timer <= 0)
            {
                timer = timerO;
                moving = true;
                destination = revealedPos;
                revealed = true;
            }
        }
        else if(revealed && !moving)
        {
            timer -= Time.deltaTime;
            // if it is done in the open, hide again
            if (timer <= 0)
            {
                timer = timerH;
                moving = true;
                destination = hiddenPos;
                revealed = false;
            }
        }
        else if(moving)
        {
            whoosh.Play();
            Move();
        }
    }

    void Move()
    {
        Vector3 moveVec = (destination.position - position);
        moveVec.Normalize();
        moveVec *= (Time.deltaTime * speed);

        position += moveVec;
        transform.position = position;

        // check how close it is to its destination
        if(Vector3.Distance(transform.position, destination.position) < 0.2f)
        {
            moving = false;
        }
    }
}
