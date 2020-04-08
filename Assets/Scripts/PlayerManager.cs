using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour
{ 

    public GameObject patient;
    public GameObject doctor;

    public GameObject player;

    public GameObject PatientCamera;
    public GameObject DoctorCamera;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(doctor);
        GameObject.Instantiate(patient);
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
        if (patient.active)
        {
            PatientCamera.SetActive(true);
            player = patient;
        }
        else
        {
            PatientCamera.SetActive(false);
        }
        if (doctor.active)
        {
            DoctorCamera.SetActive(true);
            player = doctor;
        }
        else
        {
            DoctorCamera.SetActive(false);
        }
    }
}
