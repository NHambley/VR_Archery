using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Arrow : MonoBehaviour
{
    public SteamVR_ActionSet m_ActionSet;

    public SteamVR_Action_Boolean m_SingleAction;


    private void OnTriggerEnter(Collider other)
    {
        ArrowManager.Instance.AttachBowToArrow();
        AttachArrow();
    }

    private void AttachArrow()
    {
        m_SingleAction = SteamVR_Actions._default.GrabPinch;
        m_SingleAction.GetStateDown(SteamVR_Input_Sources.Any);

        //SteamVR_Actions._default.Squeeze.Get
    }
}
