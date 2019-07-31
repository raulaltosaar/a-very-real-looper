using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    public static bool gripPressed = false;
    
    [SerializeField] private GameObject Sound;
    private FixedJoint fJoint;

    private void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);

        fJoint = GetComponent<FixedJoint>();
    }


    // Update is called once per frame
    void Update () {

        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            gripPressed = true; //collision sounds cant play
            PickUpOrDrop();
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            gripPressed = false; //collision sounds play by default
        }

    }

    void PickUpOrDrop()
    {

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            PickUpObj();
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            DropObj();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Movable")) 
        {
            Sound = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Sound = null;
    }

    void PickUpObj()
    {
        if (Sound != null)
        {
            fJoint.connectedBody = Sound.GetComponent<Rigidbody>();
            fJoint.connectedBody.transform.position = transform.position;
        }
        else
        {
            fJoint.connectedBody = null;
        }
    }

    void DropObj()
    {
        if (fJoint.connectedBody != null)
        {
            fJoint.connectedBody = Sound.GetComponent<Rigidbody>();
            fJoint.connectedBody.transform.position = transform.position;
            fJoint.connectedBody = null;
        }
    }

}
                                                                                                                                                                                              