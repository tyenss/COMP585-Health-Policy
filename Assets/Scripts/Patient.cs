using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class Patient : NetworkBehaviour
{
    public GameObject PlayerCamera;
    public bool boughtCure;
    public decimal money;
    public int patientID;
    public string patientName;
    private Door door; //door that the player is in queue, null if not

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            PlayerCamera.SetActive(true);
        }
        else
        {
            PlayerCamera.SetActive(false);
        }
        door = null;
        boughtCure = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }  
    }

    public void NewDoor(Door newDoor)
    {
        if (!newDoor.active)
        {
            return;
        }
        if (door != null)
        {
            door.DeletePatientinQueue(this);
        }
        door = newDoor;
        
    }

    public Door GetDoor()
    {
        return door;
    }

    public bool IsInline()
    {
        return door != null;
    }
}
