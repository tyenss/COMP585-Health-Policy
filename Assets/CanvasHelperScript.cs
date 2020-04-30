using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class CanvasHelperScript : NetworkBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponentInChildren<Canvas>().enabled = true;
        }
    }
}