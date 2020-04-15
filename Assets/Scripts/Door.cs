using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : MonoBehaviour
{
    public bool active;
    public Vector2 coordsToPlace;
    public Vector2 officeCoords;
    public int doorID;
    private Queue<Patient> playerQueue; //May change to linked list if performance is big issue

    // Start is called before the first frame update
    void Awake()
    {
        playerQueue = new Queue<Patient>();
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
        Patient player = GameObject.Find("Local").GetComponent<Patient>();
        if (!playerQueue.Contains(player))
        {
            AddToQueue(player);
        }
    }

    /// <summary>
    /// If patient is null or is cured, nothing happens
    /// </summary>
    /// <param name="patient"></param>
    public void AddToQueue(Patient patient)
    {
        if (patient == null || patient.cure != Patient.Cure.None)
        {
            return;
        }
        if (patient.GetDoor() != null)
        {
            patient.GetDoor().RemovePatientinQueue(patient);
        }
        patient.NewDoor(this);
        patient.transform.position = new Vector3(
            coordsToPlace.x,
            coordsToPlace.y - (float)(playerQueue.Count() * 100),
            patient.transform.position.z);
        playerQueue.Enqueue(patient);
    }

    /// <summary>
    /// Pops first patient from queue
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
        popped.NewDoor(null);
        popped.roomID = doorID;
        return popped;
    }

    /// <summary>
    /// Gets rid of a patient in the queue, no matter where they are at
    /// </summary>
    public void RemovePatientinQueue(Patient patient)
    {
        if (playerQueue.Contains(patient))
        {
            playerQueue = new Queue<Patient>(playerQueue.Where(s => s != patient));
        }
    }
}