using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public bool boughtCure;
    public decimal money;
    public int patientID;
    public string patientName;
    private Door door; //door that the player is in queue, null if not

    // Start is called before the first frame update
    void Start()
    {
        door = null;
        boughtCure = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
