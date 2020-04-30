using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using UnityEngine.UI;
using System.Linq;

public class Patient : NetworkBehaviour
{
    public GameObject PlayerCamera;
    public GameObject canvas;
    public int roomID; //Door ID is used to determine what room patient is in
                       //If roomID = 0, else they are in office
    public enum Cure { None, Bandaid, Stitches };
    public Cure cure;
    public int money;
    public int patientID;
    public string patientName;
    private Door door; //door that the player is in queue, null if not

    public Text health;
    public Text cured;
    public Text moneyText;

    public GameObject enterButton;

    //public localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.name = "Local";
        //isLocalPlayer
        if (base.hasAuthority)
        {
            PlayerCamera.SetActive(true);
            CmdAddPatientToList(this.netId);
           // canvas.SetActive(true);
            GetComponentInChildren<Canvas>().enabled = true;
            GameObject.Find("EnterDoor").GetComponent<Button>().onClick.AddListener(() => CmdEnterRoom());

        }
        else
        {
            PlayerCamera.SetActive(false);
            //canvas.SetActive(false);
        }
        door = null;
        cure = Cure.None;
        patientID = GlobalVariables.patientList.Count;
        gameObject.name = "Local";
        health.text = String.Concat("Health: :",GetRandomHealth().ToString());
        EnableDisableButtons(false);
    }

    void Update()
    {
        //isLocalPlayer
        if (!base.hasAuthority)
        {
            return;
        }

        moneyText.text = String.Concat("Money: ", money.ToString());
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

    }
    

    public void NewDoor(Door newDoor)
    {
        if (newDoor == null)
        {
            return;
            //Edge case that should not occur
            //CmdRemovePatientinQueue(this.GetInstanceID(), door.doorID);
        }
        if (!newDoor.active)
        {
            return;
        }
        if (door != null)
        {
            CmdRemovePatientinQueue(this.netId, door.doorID);
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

    private int GetRandomHealth()
    {
        System.Random random = new System.Random();
        int num = random.Next(0, 2);
        for (int i = 1; i < 10; i++)
        {
            int nextNumber = (int)random.Next(0, 10);
            num = (nextNumber > GlobalVariables.chanceOfOne) ? (int)(1 * Math.Pow(10, i)) + num : (int)(0 * Math.Pow(10, i) + num);
        }
        return num;
    }




    /// <summary>
    /// If patient is null or is cured, nothing happens
    /// </summary>
    /// <param name="instanceID"></param>
    [Command]
    public void CmdAddToQueue(uint instanceID, int doorID)
    {
        Patient patient = GlobalVariables.patientList.First(x => x.netId == instanceID);
        Door localDoor = FindObjectsOfType<Door>().First(x => x.doorID == doorID);
        if (patient == null || patient.cure != Patient.Cure.None)
        {
            return;
        }
        if (patient.GetDoor() != null)
        {
            localDoor.playerQueue.Remove(patient);
        }
        localDoor.playerQueue.Add(patient);
        patient.NewDoor(localDoor);
        Vector3 patientCoords = new Vector3(
            localDoor.coordsToPlace.x,
            localDoor.coordsToPlace.y - (float)((localDoor.playerQueue.Count() - 1) * 100),
            patient.transform.position.z);
        patient.transform.position = patientCoords;
        RpcMovePatient(patientCoords);
    }

    /// <summary>
    /// Pops first patient from queue
    /// </summary>
    /// <returns>patient in front of queue. If queue is empty, returns null</returns>
    [Command]
    public void CmdPopQueue(int doorID)
    {
        Door localDoor = FindObjectsOfType<Door>().First(x => x.doorID == doorID);
        if (!localDoor.playerQueue.Any())
        {
            return;
        }
        Patient popped = localDoor.playerQueue.First();
        localDoor.playerQueue.RemoveAt(0);
        if (localDoor.playerQueue.Any())
        {
            foreach (Patient patient in localDoor.playerQueue)
            {
                RpcMovePatient(new Vector3(localDoor.coordsToPlace.x,
                    localDoor.coordsToPlace.y + 100,
                    patient.transform.position.z));
            }
        }
        popped.NewDoor(null);
        popped.roomID = doorID;
        popped.transform.position = localDoor.officeCoords;
        EnableDisableButtons(true);
    }

    /// <summary>
    /// Removes patient in the queue, irregardless of position
    /// </summary>
    [Command]
    public void CmdRemovePatientinQueue(uint instanceID, int doorID)
    {
        Patient patient = GlobalVariables.patientList.First(x => x.netId == instanceID);
        //Patient patient = GameObject.FindObjectsOfType<Patient>().First(x => x.isLocalPlayer);
        Door localDoor = FindObjectsOfType<Door>().First(x => x.doorID == doorID);
        if (localDoor.playerQueue.Contains(patient))
        {
            localDoor.playerQueue.Remove(patient);
        }
    }

    [Command]
    public void CmdAddPatientToList(uint instanceID)
    {
        GlobalVariables.patientList.Add(FindObjectsOfType<Patient>().First(x => x.netId == instanceID));
    }

    /// <summary>
    /// Makes patient buttons active or inactive
    /// </summary>
    /// <param name="b">true: active, false: inactive</param>
    public static void EnableDisableButtons(bool b)
    {
        if (GlobalVariables.buttons.Count == 0)
        {
            GlobalVariables.buttons.AddRange(GameObject.FindGameObjectsWithTag("PatientButton"));
        }
        foreach (GameObject button in GlobalVariables.buttons)
        {
            button.SetActive(b);
        }
    }

    [ClientRpc]
    public void RpcPopQueue(uint doorId)
    {
        Door door = FindObjectsOfType<Door>().First(x => x.netId == doorId);
    }

    [ClientRpc]
    public void RpcRemovePatientInQueue(uint instanceID, uint doorId)
    {
        Door door = FindObjectsOfType<Door>().First(x => x.netId == doorId);
        Patient patient = GlobalVariables.patientList.First(x => x.netId == instanceID);

    }

    [ClientRpc]
    public void RpcMovePatient(Vector3 patientCoords)
    {
        transform.position = patientCoords;
    }
    public void RpcEnterRoom()
    {
        Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        Door door = patient.GetDoor();
        if (door != null)
        {
            roomID = door.doorID;
            CmdPopQueue(door.doorID);
        }
    }

    public void CmdEnterRoom()
    {
        Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        Door door = patient.GetDoor();
        if (door != null)
        {
            roomID = door.doorID;
            CmdPopQueue(door.doorID);
        }
    }

}



