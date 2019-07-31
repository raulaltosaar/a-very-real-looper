using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOneShot : MonoBehaviour {

    // see TriggerNote_Or_Clip_AndEffect for relevant comments. this script is even simpler than TriggerTexture; it just plays a specific one-shot sound, once.
    public string OSCAddress;

    private void Start()
    {
            OSCHandler.Instance.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
            OSCHandler.Instance.SendMessageToClient("Touch", OSCAddress, 1f);
    }

    private void OnTriggerExit(Collider other)
    {
            OSCHandler.Instance.SendMessageToClient("Touch", OSCAddress, 0f);
    }

}
