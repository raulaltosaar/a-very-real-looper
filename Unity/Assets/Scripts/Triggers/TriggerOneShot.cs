using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOneShot : MonoBehaviour {

    public string AbletonOSCAddress;

    private void Start()
    {
            OSCHandler.Instance.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
            OSCHandler.Instance.SendMessageToClient("Touch", AbletonOSCAddress, 1f);
    }

    private void OnTriggerExit(Collider other)
    {
            OSCHandler.Instance.SendMessageToClient("Touch", AbletonOSCAddress, 0f);
    }

}
