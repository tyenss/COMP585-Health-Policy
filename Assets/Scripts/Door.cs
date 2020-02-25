using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : MonoBehaviour
{
    public bool active;
    public Vector2 coordsToPlace;
    public Vector2 officeCoords;
    private Queue<Patient> playerQueue;

    // Start is called before the first frame update
    void Start()
    {
           playerQueue = new Queue<Patient>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Patient player = FindObjectOfType(typeof(Patient)) as Patient;
        if (!playerQueue.Contains(player))
        {
            AddToQueue(player);
        }
    }

    public void AddToQueue(Patient patient)
    {
        patient.transform.position = new Vector3(
            coordsToPlace.x,
            coordsToPlace.y - (float)(playerQueue.Count() * 100),
            patient.transform.position.z);
        playerQueue.Enqueue(patient);
    }

    /// <summary>
    /// Pops patient
    /// </summary>
    /// <returns>patient in front of queue. If queue is empty, returns null</returns>
    public Patient PopQueue()
    {
        if (playerQueue.Peek() == null)
        {
            return null;
        }
        Patient popped = playerQueue.Dequeue();
        foreach (Patient patient in playerQueue)
        {
            patient.transform.position = new Vector3(coordsToPlace.x,
                coordsToPlace.y + 100,
                patient.transform.position.z);
        }
        return popped;
    }
}
