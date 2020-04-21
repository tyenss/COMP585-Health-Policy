using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Mirror;
using System;

//[System.Serializable]
public class Door : NetworkBehaviour
{
    public bool active;
    public Vector2 coordsToPlace;
    public Vector2 officeCoords;
    public int doorID;

    //public readonly SyncListPatient playerQueue = new SyncListPatient();

    //private readonly SyncListItem playerQueue = new SyncListItem(); //May change to linked list if performance is big issue
    public List<Patient> playerQueue;
    // Start is called before the first frame update
    void Awake()
    {
        playerQueue = new List<Patient>();
    }

    /// database access for queue
    //public void queueDB()
    //{
    //    StartCoroutine(addPatient());
    //}

    //IEnumerator addPatient()
    //{
    //    WWWForm form = new WWWForm();
    //    ///form.AddField("name", player.name);
    //    WWW www = new WWW("http://localhost/sqlconnect/connection.php");
    //    yield return www;
    //    if (www.text == "0")
    //    {
    //        Debug.Log("Patient added successfully");
    //    }
    //    else 
    //    {
    //        Debug.Log("error");
    //    }
    //}





    /// <summary>
    /// Make compatible for tablet
    /// </summary>
    void OnMouseDown()
    {
        //Patient player = FindObjectOfType(typeof(Patient)) as Patient;
        //Patient player = GameObject.Find("Local").GetComponent<Patient>();
        Patient player = GameObject.FindObjectsOfType<Patient>().First(x => x.hasAuthority);
        var asdf = FindObjectsOfType<Patient>();
        if (!this.playerQueue.Contains(player))
        {
            player.CmdAddToQueue(player.netId, this.doorID);
        }
        //if (!this.playerQueue.Contains(playerQueue.Where(x => x.patient == player)))
        //{
        //    AddToQueue(player);
        //}
    }

    ///// <summary>
    ///// If patient is null or is cured, nothing happens
    ///// </summary>
    ///// <param name="instanceID"></param>
    //[Command]
    //public void CmdAddToQueue(int instanceID)
    ////public void AddToQueue(Patient patient)
    //{
    //    Patient[] patients = FindObjectsOfType<Patient>();
    //    Patient patient = patients.AsEnumerable().First(x => x.GetInstanceID() == instanceID);
    //    if (patient == null || patient.cure != Patient.Cure.None)
    //    {
    //        return;
    //    }
    //    if (patient.GetDoor() != null)
    //    {
    //        patient.GetDoor().CmdRemovePatientinQueue(patient.GetInstanceID());
    //    }
    //    this.playerQueue.Add(patient);
    //    //this.playerQueue.Add(new Player(patient));
    //    patient.NewDoor(this);
    //    patient.transform.position = new Vector3(
    //        coordsToPlace.x,
    //        coordsToPlace.y - (float)((playerQueue.Count() - 1) * 100),
    //        patient.transform.position.z);
    //}

    ///// <summary>
    ///// Pops first patient from queue
    ///// </summary>
    ///// <returns>patient in front of queue. If queue is empty, returns null</returns>
    //[Command]
    //public void CmdPopQueue()
    ////public Patient PopQueue()
    //{
    //    //if (this.playerQueue.First<Patient>() == null)
    //    //{
    //    //    return null;
    //    //}
    //    if (!this.playerQueue.Any())
    //    {
    //        return;// null;
    //    }
    //    Patient popped = playerQueue.First();
    //    //Patient popped = this.playerQueue.First<Player>().patient;
    //    this.playerQueue.RemoveAt(0);
    //    if (playerQueue.Any())
    //    {
    //        foreach (Patient patient in playerQueue)
    //        {
    //            patient.transform.position = new Vector3(coordsToPlace.x,
    //                coordsToPlace.y + 100,
    //                patient.transform.position.z);
    //        }
    //        //foreach (Player patient in playerQueue)
    //        //{
    //        //    patient.patient.transform.position = new Vector3(coordsToPlace.x,
    //        //        coordsToPlace.y + 100,
    //        //        patient.patient.transform.position.z);
    //        //}
    //    }
    //    popped.NewDoor(null);
    //    popped.roomID = doorID;
    //    popped.transform.position = this.officeCoords;
    //    ButtonHandler.EnableDisableButtons(true);
    //    //return popped;
    //}

    ///// <summary>
    ///// Removes patient in the queue, irregardless of position
    ///// </summary>
    //[Command]
    //public void CmdRemovePatientinQueue(int instanceID)
    ////public void RemovePatientinQueue(Patient patient)
    //{
    //    Patient[] patients = FindObjectsOfType<Patient>();
    //    Patient patient = patients.AsEnumerable().First(x => x.GetInstanceID() == instanceID);
    //    if (this.playerQueue.Contains(patient))
    //    {
    //        this.playerQueue.Remove(patient);
    //    }
    //    //if (this.playerQueue.Contains(playerQueue.Where(x => x.patient == patient)))
    //    //{
    //    //    this.playerQueue.Remove(playerQueue.First(x => x.patient == patient));
    //    //}
    //}
}