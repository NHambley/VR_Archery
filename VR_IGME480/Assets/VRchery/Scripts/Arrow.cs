using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    ScoreTimerScript manager;
    AudioSource hit;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<ScoreTimerScript>();
        hit = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if(collision.gameObject.tag == "Target")
        {
            rb.isKinematic = true;
            transform.parent = collision.transform;
            manager.AddScore(10);
            hit.Play();
        }
    }
}
