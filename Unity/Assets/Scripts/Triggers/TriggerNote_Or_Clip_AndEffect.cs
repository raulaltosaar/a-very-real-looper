using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNote_Or_Clip_AndEffect : MonoBehaviour {

    // by default the vive controller is not inside a trigger
    bool controllerInTrigger = false;

    // we would like to loop the sounds we trigger. to achieve this, we need a "play" and "stop" functionality
    // an enumerator called PlayState will help us
    enum PlayState { Normal = 0, Playing = 1 }

    // our default state is Normal: when you collide with a trigger, a sound plays, but, when you leave the trigger, the sound stops
    // the Playing state: when you leave the trigger and it is in the Playing state, the sound keeps playing
    PlayState playState = PlayState.Normal;

    // the OSC addresses we are sending information to. OSCAddress is used for sending on/off messages. EffectOSCAddress is used to send continuous controller position data
    public string OSCAddress;
    public string EffectOSCAddress;

    // we would like to trigger a sound with one hand and then control an effect with the other, while we are triggering that sound
    // thus we need to know which controller (left or right) is triggering a sound so that the other controller can control the effect
    // so we create two public variables 
    public GameObject leftController;
    public GameObject rightController;

    // and two private variables of class ControllerPosition (from the ControllerPosition.cs script)
    private ControllerPosition leftPosition;
    private ControllerPosition rightPosition;

    private void Start()
    {
        // initialize the OSC Handler
        OSCHandler.Instance.Init();

        // we are informed by the UpdatePlayState.cs script when the "Menu" button is pressed, and then we run a function called ChangePlayState
        UpdatePlayState.onMenuPress += ChangePlayState;

        // we get the vertical controller position from the ControllerPosition.cs script attached to each controller
        leftPosition = leftController.GetComponent<ControllerPosition>();
        rightPosition = rightController.GetComponent<ControllerPosition>();
    }

    public void ChangePlayState()
    {
        // do nothing if we press the menu button but are not inside of a trigger
        if (!controllerInTrigger) return;

        // if the sound is looping turn looping off
        if (playState == PlayState.Playing)
        {
            playState = PlayState.Normal;
        }
        
        // if the sound is not looping, turn looping on
        else
        {
            playState = PlayState.Playing;
        }
    }

    // when we collide with a trigger
    private void OnTriggerStay(Collider other)
    {
        // make some NOISE if the "Grip" button is not pressed!
        if (MoveTrigger.gripPressed == false)
        {
            // by sending a "1" to TouchDesigner
            controllerInTrigger = true;
            OSCHandler.Instance.SendMessageToClient("Touch", OSCAddress, 1f);

            // and then, if the left controller is triggering the sound, use the right controller's position to control an effect
            if (other.tag == "Left")
            {
                OSCHandler.Instance.SendMessageToClient("Touch_Position", EffectOSCAddress, rightPosition.yPosition);
            }

            // and vice versa
            if (other.tag == "Right")
            {
                OSCHandler.Instance.SendMessageToClient("Touch_Position", EffectOSCAddress, leftPosition.yPosition);
            }
        }
    }

    // when we stop colliding with a trigger 
    private void OnTriggerExit(Collider other)
    {
        // and it is not in the looping state
        if (playState == PlayState.Normal)
        {
            // turn it off by sending a "0" to TouchDesigner
            OSCHandler.Instance.SendMessageToClient("Touch", OSCAddress, 0f);
        }
        controllerInTrigger = false;
    }

}
