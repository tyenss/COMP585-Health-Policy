using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using UnityEngine.UI;

[Serializable]
public class Patient : NetworkBehaviour
{
    public GameObject PlayerCamera;
    public int roomID; //Door ID is used to determine what room patient is in
                       //If roomID = 0, else they are in office
    public enum Cure { None, Bandaid, Stitches };
    public Cure cure;
    public int money;
    public int patientID;
    public string patientName;

    private Door door; //door that the player is in queue, null if not

    public Text health;
    public Text cured;
    public Text moneyText;

    //public localPlayer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "Local";
        if (isLocalPlayer)
        {
            PlayerCamera.SetActive(true);
        }
        else
        {
            PlayerCamera.SetActive(false);
        }
        door = null;
        cure = Cure.None;
        GlobalVariables.patientList.Add(this);
        patientID = GlobalVariables.patientList.Count;
        health.text = String.Concat("Health: :",GetRandomHealth().ToString());
        ButtonHandler.EnableDisableButtons(false);
        //this.gameObject.GetComponent<Camera>().
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        moneyText.text = String.Concat("Money :", money.ToString());
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        //gameObject.name = "Local";
    }

    public void NewDoor(Door newDoor)
    {
        //GameObject.Instantiate(
        if (newDoor == null)
        {
            door = newDoor;
            return;
        }
        if (!newDoor.active)
        {
            return;
        }
        if (door != null)
        {
            door.RemovePatientinQueue(this);
        }
        door = newDoor;
        
    }

    public Door GetDoor()
    {
        return door;
    }

    public bool IsInline()
    {
        return door != null;
    }

    private int GetRandomHealth()
    {
        System.Random random = new System.Random();
        int num = random.Next(0, 10);
        for (int i = 1; i < 10; i++)
        {
            int nextNumber = (int)random.Next(0, 10);
            num = nextNumber > GlobalVariables.chanceOfOne ? (int)(1 * Math.Pow(10, i)) + num : (int)(0 * Math.Pow(10, i) + num);
        }
        return num;
    }
}
