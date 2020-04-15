using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{ 

    public GameObject patient;
    public GameObject doctor;

    //public GameObject player;
    public GameObject playerCamera;
    //public GameObject PatientCamera;
    //public GameObject DoctorCamera;

    private GameObject patient1;
    private GameObject doctor1;
    // Start is called before the first frame update
    void Start()
    {
        /*
        System.Random random = new System.Random();
        
        if (random.Next(2) == 1)
        {
            patient1 = Instantiate(patient);
        } else
        {
            doctor1 = Instantiate(doctor);
            doctor1.GetComponent<Camera>().tag = "MainCamera";
        }
        */
       // patient1 = Instantiate(patient);
        doctor1 = Instantiate(doctor);
        playerCamera = GameObject.FindWithTag("MainCamera");
        playerCamera.SetActive(true);

        //GameObject.Instantiate(doctor);
        //patient1 = Instantiate(patient);
        //patient1.GetComponent<Camera>().tag = "MainCamera";
        //patient1.GetComponent<Camera>().enabled = true;
    }
    /*
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        player.GetComponent<Player>().color = Color.red;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
    public void OnStartLocalPlayer()
    */
    // Update is called once per frame
    void Update()
    {
        //if (patient1.active)
        //if (patient.active)
        //{
        //    PatientCamera.SetActive(true);
        //    player = patient;
        //}
        //else
        //{
        //    PatientCamera.SetActive(false);
        //}
        //if (doctor.active)
        //{
        //    DoctorCamera.SetActive(true);
        //    player = doctor;
        //}
        //else
        //{
        //    DoctorCamera.SetActive(false);
        //}
    }
}
