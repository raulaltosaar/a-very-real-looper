using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNote_Or_Clip_AndEffect : MonoBehaviour {

    bool controllerInSphere = false;
    enum PlayState { Normal = 0, Playing = 1 }
    PlayState playState = PlayState.Normal;

    public string AbletonOSCAddress;
    public string AbletonEffectOSCAddress;

    public GameObject leftController;
    public GameObject rightController;
    private SendControllerPosition leftPosition;
    private SendControllerPosition rightPosition;

    private void Start()
    {
        OSCHandler.Instance.Init();
        UpdatePlayState.onMenuPress += ChangePlayState;

        leftPosition = leftController.GetComponent<SendControllerPosition>();
        rightPosition = rightController.GetComponent<SendControllerPosition>();
    }

    public void ChangePlayState()
    {
        if (!controllerInSphere) return;

        if (playState == PlayState.Playing)
        {
            playState = PlayState.Normal;
        }
        else
        {
            playState = PlayState.Playing;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (MoveTrigger.gripPressed == false)
        {
            controllerInSphere = true;
            OSCHandler.Instance.SendMessageToClient("Touch", AbletonOSCAddress, 1f);

            if (other.tag == "Left")
            {
                OSCHandler.Instance.SendMessageToClient("Touch_Position", AbletonEffectOSCAddress, rightPosition.yPosition);
            }

            if (other.tag == "Right")
            {
                OSCHandler.Instance.SendMessageToClient("Touch_Position", AbletonEffectOSCAddress, leftPosition.yPosition);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playState == PlayState.Normal)
        {
            OSCHandler.Instance.SendMessageToClient("Touch", AbletonOSCAddress, 0f);
        }
        controllerInSphere = false;
    }

}
