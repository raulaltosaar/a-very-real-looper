using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayState : MonoBehaviour {

    // access Vive controllers
    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;

    // create delegate to track when controllers' "Menu" button is pressed
    public delegate void OnMenuPress();

    // populate that delegate with a method 
    public static OnMenuPress onMenuPress;

    // Use this for initialization
    void Start () {
    trackedObject = GetComponent<SteamVR_TrackedObject>();
    device = SteamVR_Controller.Input((int)trackedObject.index);
    }
	
	// Update is called once per frame
	void Update () {

        // if the controllers' "Menu" button is pressed, run the onMenuPress method which is accessed by the TriggerNote_Or_Clip_AndEffect.cs script
        if (device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu))
        {
            if (onMenuPress != null)
            {
                onMenuPress();
            }
        }
    }
}
