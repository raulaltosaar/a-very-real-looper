using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPosition : MonoBehaviour {

    // access two Vive controllers
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    // create variable to hold controllers' vertical position
    public float yPosition; 

    // Use this for initialization
    void Start () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    public void Update()
    {
        // populate variable with controllers' current vertical position
        yPosition = transform.position.y;
    }
}
