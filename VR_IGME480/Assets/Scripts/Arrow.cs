using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/*
Touchpad	Touch	Left: 18
                    Right: 19	
Touchpad	Press	Left: 16
                    Right: 17	
Touchpad	Horizontal Movement	-	Left: 17
                                    Right: 19	 Axis values: –1.0 to 1.0
Touchpad	Vertical Movement	-	Left: 18
                                    Right: 20	Axis values –1.0 to 1.0
Thumbstick	Press	Left: 8
                    Right: 9	
Thumbstick	Horizontal Movement	-	Left: 1
                                    Right: 4	Axis values –1.0 to 1.0
Thumbstick	Vertical Movement	-	Left: 2
                                    Right: 5	Axis values –1.0 to 1.0
Select Trigger	Press	Left: 14
                        Right: 15	-	-
Select Trigger	Squeeze	-	Left: 9
                            Right: 10	Axis values 0.0 to 1.0
Grip button	Press	Left: 4
                    Right: 5	-	-
Grip button	Squeeze	-	Left: 11
                        Right: 12	0.0 and 1.0*
Menu button	Press	Left: 6
                    Right: 7	-	- 
*/
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
        // check light diver rework for input help
        
        if(!isAttached && Input.GetKeyDown(KeyCode.Joystick1Button15))
        {
            ArrowManager.Instance.AttachBowToArrow();
            isAttached = true;
        }
        
    }
}
