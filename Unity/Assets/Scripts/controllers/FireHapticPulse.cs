using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHapticPulse : MonoBehaviour {

    // access vive controllers
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    private void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    // while controller is held inside of a trigger fire a haptic pulse of strength 1500 
    private void OnTriggerStay(Collider other)
    {
        device.TriggerHapticPulse(1500);
    }
}
