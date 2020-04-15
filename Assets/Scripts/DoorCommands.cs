using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

public class DoorCommands : NetworkBehaviour
{
    ///// <summary>
    ///// If patient is null or is cured, nothing happens
    ///// </summary>
    ///// <param name="instanceID"></param>
    //[Command]
    //public void CmdAddToQueue(int instanceID, int doorID)
    ////public void AddToQueue(Patient patient)
    //{
    //    Patient[] patients = FindObjectsOfType<Patient>();
    //    Patient patient = patients.AsEnumerable().First(x => x.GetInstanceID() == instanceID);
    //    Door door = FindObjectsOfType<Door>().First(x => x.doorID == doorID);
    //    if (patient == null || patient.cure != Patient.Cure.None)
    //    {
    //        return;
    //    }
    //    if (patient.GetDoor() != null)
    //    {
    //        CmdRemovePatientinQueue(patient.GetInstanceID(), doorID);
    //    }
    //    door.playerQueue.Add(patient);
    //    //this.playerQueue.Add(new Player(patient));
    //    patient.NewDoor(door);
    //    patient.transform.position = new Vector3(
    //        door.coordsToPlace.x,
    //        door.coordsToPlace.y - (float)((door.playerQueue.Count() - 1) * 100),
    //        patient.transform.position.z);
    //}

    ///// <summary>
    ///// Pops first patient from queue
    ///// </summary>
    ///// <returns>patient in front of queue. If queue is empty, returns null</returns>
    //[Command]
    //public void CmdPopQueue(int doorID)
    ////public Patient PopQueue()
    //{
    //    Door door = FindObjectsOfType<Door>().First(x => x.doorID == doorID);
    //    //if (this.playerQueue.First<Patient>() == null)
    //    //{
    //    //    return null;
    //    //}
    //    if (!door.playerQueue.Any())
    //    {
    //        return;// null;
    //    }
    //    Patient popped = door.playerQueue.First();
    //    //Patient popped = this.playerQueue.First<Player>().patient;
    //    door.playerQueue.RemoveAt(0);
    //    if (door.playerQueue.Any())
    //    {
    //        foreach (Patient patient in door.playerQueue)
    //        {
    //            patient.transform.position = new Vector3(door.coordsToPlace.x,
    //                door.coordsToPlace.y + 100,
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
    //    popped.transform.position = door.officeCoords;
    //    ButtonHandler.EnableDisableButtons(true);
    //    //return popped;
    //}

    ///// <summary>
    ///// Removes patient in the queue, irregardless of position
    ///// </summary>
    //[Command]
    //public void CmdRemovePatientinQueue(int instanceID, int doorID)
    ////public void RemovePatientinQueue(Patient patient)
    //{
    //    Patient[] patients = FindObjectsOfType<Patient>();
    //    Patient patient = patients.AsEnumerable().First(x => x.GetInstanceID() == instanceID);
    //    Door door = FindObjectsOfType<Door>().First(x => x.doorID == doorID);
    //    if (door.playerQueue.Contains(patient))
    //    {
    //        door.playerQueue.Remove(patient);
    //    }
    //    //if (this.playerQueue.Contains(playerQueue.Where(x => x.patient == patient)))
    //    //{
    //    //    this.playerQueue.Remove(playerQueue.First(x => x.patient == patient));
    //    //}
    //}
}
