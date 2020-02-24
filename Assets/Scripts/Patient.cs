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

    void GoInline(Door newDoor)
    {
        if (newDoor.active || newDoor == null)
        {
            door = newDoor;
        }
    }

    public bool IsInline()
    {
        return door != null;
    }
}
