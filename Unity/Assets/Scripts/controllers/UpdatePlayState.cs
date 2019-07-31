using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayState : MonoBehaviour {

    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;

    public delegate void OnMenuPress();
    public static OnMenuPress onMenuPress;

    // Use this for initialization
    void Start () {
    trackedObject = GetComponent<SteamVR_TrackedObject>();
    device = SteamVR_Controller.Input((int)trackedObject.index);
    }
	
	// Update is called once per frame
	void Update () {
        if (device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_ApplicationMenu))
        {
            if (onMenuPress != null)
            {
                onMenuPress();
            }
        }
    }
}
