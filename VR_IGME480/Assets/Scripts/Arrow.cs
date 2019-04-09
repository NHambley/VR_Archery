using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Arrow : MonoBehaviour
{
    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_SingleAction;

    bool isAttached = false;

    private bool isFired = false;

    private void OnTriggerStay(Collider other)
    {
        AttachArrow();
    }

    private void OnTriggerEnter(Collider other)
    {
        AttachArrow();
    }

    private void Update()
    {
        if (isFired)
        {
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }
    }

    public void Fired()
    {
        isFired = true;
    }

    private void AttachArrow()
    {
        /*
        if(!isAttached && input code){
            Arrow.Instance.AttachBowToArrow();
            isAttached = true;
        }
        */
    }
}
