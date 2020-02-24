using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool active;
    public Queue<Patient> playerQueue;
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
        //Add something that detects the client
        Patient player = GameObject.FindObjectOfType(typeof(Patient)) as Patient;
        //playerQueue.
    }
}
