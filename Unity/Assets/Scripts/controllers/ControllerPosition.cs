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
        // we populate the variable with controllers' current vertical position (y axis) every frame.

        // however,
        // SteamVR calculates the controllers' vertical position using the distance from the floor which is created when you calibrate your play-area with SteamVR
        // we want to meaningfully control effects using the controllers' vertical position. 
        // so we subtract 1.5 from the current vertical position, essentially setting the floor higher than it actually is. 
        // this way we get more usable 0-1 values that correspond better to real life movement.

        yPosition = transform.position.y-1.25f;
    }
}
