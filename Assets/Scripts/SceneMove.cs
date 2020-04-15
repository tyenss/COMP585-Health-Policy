using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public Vector3 waitingRoom;
    //public Door door;
    //public Patient patient;


    
    public void MoveToOffice(Door door, Vector3 newPosition)
    {
        //Patient patient = door.PopQueue();
        //patient.gameObject.transform.position = newPosition;
    }

    public void MoveToLobby(Patient patient, Vector3 newPosition)
    {
        //patient.gameObject.transform.position = newPosition;
    }

    public void Update()
    {
        //Must be added to a button for the doctor in the future
        //if (Input.GetKeyDown(KeyCode.Alpha9))
        //{
        //    Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        //    //move to office
        //    if (patient.GetDoor() != null)
        //    {
        //        //patient.transform.position = patient.GetDoor().officeCoords;
        //        patient.transform.position = patient.GetDoor().officeCoords;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        //    //move to lobby
        //    //Patient player = FindObjectOfType(typeof(Patient)) as Patient; //Fix for networking code
        //    patient.GetDoor().RemovePatientinQueue(patient);
        //    patient.transform.position = waitingRoom;
        //}
    }
}
