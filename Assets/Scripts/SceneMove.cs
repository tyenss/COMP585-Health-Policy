using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public Vector3 waitingRoom;
    public Door door;

    public void MoveToOffice(Door door, Vector3 newPosition)
    {
        Patient patient = door.PopQueue();
        patient.gameObject.transform.position = newPosition;
    }

    public void MoveToLobby(Patient patient, Vector3 newPosition)
    {
        patient.gameObject.transform.position = newPosition;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //move to office
            Patient patient = door.PopQueue();
            patient.transform.position = door.officeCoords;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //move to lobby
            Patient player = FindObjectOfType(typeof(Patient)) as Patient; //Fix for networking code
            player.transform.position = waitingRoom;
        }
    }
}
