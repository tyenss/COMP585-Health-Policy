using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class Patient : NetworkBehaviour
{
    public GameObject PlayerCamera;
    public int roomID;
    public enum Cure { None, Bandaid, Stitches };
    public Cure cure;
    public int money;
    public int patientID;
    public string patientName;
    private Door door; //door that the player is in queue, null if not

    //public localPlayer;

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
        cure = Cure.None;
        GlobalVariables.patientList.Add(this);
        patientID = GlobalVariables.patientList.Count;
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (this.GetDoor() != null)
            {
                this.roomID = GetDoor().doorID;
                this.GetDoor().RemovePatientinQueue(this);
                this.transform.position = this.GetDoor().officeCoords;
                this.door = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            this.roomID = 0;
            this.transform.position = new Vector3(0f, 0f, 0f);
        }

        BuyMedicine();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
    }

    public void NewDoor(Door newDoor)
    {
        if (!newDoor.active)
        {
            return;
        }
        if (door != null)
        {
            door.RemovePatientinQueue(this);
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

    public void BuyMedicine()
    {
        if (roomID > 0)
        {
            Doctor doctor = GlobalVariables.doctorList.Find(x => x.doctorID == roomID);
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (money >= doctor.stitchesPrice)
                {
                    doctor.StitchesSold();
                    cure = Cure.Stitches;
                    money -= doctor.stitchesPrice;
                }
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                if (money >= doctor.bandaidPrice)
                {
                    doctor.BandaidSold();
                    cure = Cure.Bandaid;
                    money -= doctor.bandaidPrice;
                }
            }
        }
    }
}
