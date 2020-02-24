using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public void MoveToOffice(Door door, Vector3 newPosition)
    {
        Patient patient = door.playerQueue.Dequeue();
        patient.gameObject.transform.position = newPosition;
    }

    public void MoveToLobby(Patient patient, Vector3 newPosition)
    {
        patient.gameObject.transform.position = newPosition;
    }
}
