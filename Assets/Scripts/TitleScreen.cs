using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;

public class TitleScreen : NetworkBehaviour
{
    public Camera Cam1;
    // Start is called before the first frame update
    void Start()
    {
        Cam1.enabled = true;
        Cam1.aspect = (Screen.currentResolution.width / Screen.currentResolution.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
