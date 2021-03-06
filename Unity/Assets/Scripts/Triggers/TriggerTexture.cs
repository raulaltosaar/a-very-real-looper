﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTexture : MonoBehaviour {

    // see TriggerNote_Or_Clip_AndEffect.cs for relevant comments. this script is much simpler; it just loops and stops looping a clip.
    bool controllerInSphere = false;
    enum PlayState { Normal = 0, Playing = 1 }
    PlayState playState = PlayState.Normal;

    public string AbletonClipOSCAddress;

    private void Start()
    {
        OSCHandler.Instance.Init();
        UpdatePlayState.onMenuPress += ChangePlayState;
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
            OSCHandler.Instance.SendMessageToClient("Touch", AbletonClipOSCAddress, 1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (playState == PlayState.Normal)
        {
            OSCHandler.Instance.SendMessageToClient("Touch", AbletonClipOSCAddress, 0f);
        }
        controllerInSphere = false;
    }

}
