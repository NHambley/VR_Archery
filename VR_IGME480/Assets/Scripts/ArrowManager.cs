using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ArrowManager : MonoBehaviour
{
    public static ArrowManager Instance;

    public SteamVR_Behaviour_Pose trackedObj;

    private GameObject currentArrow;

    public GameObject stringAttachPoint;
    public GameObject arrowStartPoint;

    public GameObject arrowPrefab;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AttachArrow();
    }

    private void AttachArrow()
    {
        if(currentArrow == null)
        {
            currentArrow = Instantiate(arrowPrefab);
            currentArrow.transform.parent = trackedObj.transform;
            currentArrow.transform.localPosition = new Vector3(0f, 0f, 0.342f);
        }
    }

    public void AttachBowToArrow()
    {
        currentArrow.transform.parent = stringAttachPoint.transform;
        currentArrow.transform.localPosition = arrowStartPoint.transform.localPosition;
        currentArrow.transform.rotation = arrowStartPoint.transform.rotation;
    }
}
