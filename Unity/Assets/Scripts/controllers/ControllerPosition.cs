using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPosition : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    public float yPosition; 

    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    public void Update()
    {
        yPosition = transform.position.y;
    }


}
