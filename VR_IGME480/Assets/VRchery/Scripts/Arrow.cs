using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    ScoreTimerScript manager;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<ScoreTimerScript>();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        if(collision.gameObject.tag == "Target")
        {
            rb.isKinematic = true;
            transform.parent = collision.transform;
            manager.AddScore(10);
        }
    }
}
