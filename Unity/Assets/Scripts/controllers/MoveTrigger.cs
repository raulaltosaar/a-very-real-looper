using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour {

    // to access our two Vive controllers
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    // the gripPressed boolean tracks the state of the Vive controller's grip button
    // by default the grip is not pressed and we have our default, desired functionality: sound plays when you collide with a trigger
    public static bool gripPressed = false;

    // these variables are used for picking up and dropping a trigger in a new location
    [SerializeField] private GameObject Trigger;
    private FixedJoint fJoint;

    private void Start()
    {
        // access our two Vive controllers
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);

        // access the fixed joint attached to both controllers
        fJoint = GetComponent<FixedJoint>();
    }

    void Update () {
        // our intent when holding the grip button is to move a trigger into a new location (by intiating the PickUpOrDrop function) 
        // when moving we do not want sound to play
        // therefore the trigger does not activate when we collide with it while holding the grip button
        if (device.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            gripPressed = true; 
            PickUpOrDrop();
        }

        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            // the grip button is not pressed by default, so once the button is released it we should reset the boolean to its default state of false so that sounds can be triggered
            gripPressed = false; 
        }

    }

    void OnTriggerStay(Collider other)
    {
        // all spherical triggers are movable and so are tagged as "Movable" (big rectangular triggers are not) 
        // so we must check whether the trigger we are colliding with at the moment has that tag or not
        if (other.CompareTag("Movable"))
        {
            // if the trigger we are in is movable then we populate the empty variable "Trigger" of type GameObject with the Trigger GameObject we are currently inside of
            Trigger = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // if we exit the trigger then we are no longer inside of a trigger and must empty the "Trigger" variable
        Trigger = null;
    }

    void PickUpOrDrop()
    {
        // while the grip button is pressed and we are inside of a trigger, we can press the Vive controller's "Trigger" button to pick the trigger up
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            PickUpObj();
        }

        // while the grip button is pressed and we are inside of a trigger, we can release the Vive controller's "Trigger" button to drop the trigger in a new location
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            DropObj();
        }
    }

    void PickUpObj()
    {
        // if we are inside a trigger
        if (Trigger != null)
        {
            // then attach the controller's fixed joint to the trigger's Rigidbody and set the trigger's position equal to the controller's position
            // we are now moving the trigger into a new location
            fJoint.connectedBody = Trigger.GetComponent<Rigidbody>();
            fJoint.connectedBody.transform.position = transform.position;
        }
        // else if we are not inside a trigger
        else
        {
            // there is nothing to attach the controller's fixed joint to
            fJoint.connectedBody = null;
        }
    }

    void DropObj()
    {
        // if the controller is attached to a trigger
        if (fJoint.connectedBody != null)
        {

            // set the trigger's position equal to the controller's most recent, final position
            fJoint.connectedBody = Trigger.GetComponent<Rigidbody>();
            fJoint.connectedBody.transform.position = transform.position;

            // detach the controller from the trigger by setting connectedBody to null
            fJoint.connectedBody = null;
        }
    }

}
                                                                                                                                                                                              