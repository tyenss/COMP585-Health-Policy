using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class ButtonHandler : MonoBehaviour
{
    public void BuyStitches()
    {
        //Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        Patient patient = GameObject.FindObjectsOfType<Patient>().First(x => x.hasAuthority);
        if (patient.roomID > 0)
        {
            Doctor doctor = GlobalVariables.doctorList.Find(x => x.doctorID == patient.roomID);
            if (patient.money >= doctor.stitchesPrice && patient.cure == Patient.Cure.None)
            {
                doctor.StitchesSold();
                patient.cure = Patient.Cure.Stitches;
                patient.money -= doctor.stitchesPrice;
                patient.roomID = 0;
                patient.transform.position = new Vector3(0f, 0f, 0f);
            }
            patient.cured.text = "Treated: " + patient.cure.ToString();
            Patient.EnableDisableButtons(false);
        }
    }

    public void BuyBandaid()
    {
        //Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        Patient patient = GameObject.FindObjectsOfType<Patient>().First(x => x.hasAuthority);
        if (patient.roomID > 0)
        {
            Doctor doctor = GlobalVariables.doctorList.Find(x => x.doctorID == patient.roomID);
            if (patient.money >= doctor.bandaidPrice && patient.cure == Patient.Cure.None)
            {
                doctor.BandaidSold();
                patient.cure = Patient.Cure.Bandaid;
                patient.money -= doctor.bandaidPrice;
                patient.roomID = 0;
                patient.transform.position = new Vector3(0f, 0f, 0f);
            }
            patient.cured.text = "Treated: " + patient.cure.ToString();
            Patient.EnableDisableButtons(false);
        }
    }

    public void EnterRoom()
    {
        //Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        Patient patient = GameObject.FindObjectsOfType<Patient>().First(x => x.hasAuthority);
        Door door = patient.GetDoor();
        if (door != null)
        {
            patient.roomID = door.doorID;
            patient.CmdPopQueue(door.doorID);
        }
    }

    public void LeaveRoom()
    {
        //Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        Patient patient = GameObject.FindObjectsOfType<Patient>().First(x => x.hasAuthority);
        patient.roomID = 0;
        patient.transform.position = new Vector3(0f, 0f, 0f);
        Patient.EnableDisableButtons(false);
    }

    

    public void SetBandaidPrice(Text text)
    {
        Doctor doctor = GameObject.Find("Local").GetComponent<Doctor>();
        //Text text = GameObject.Find("BandaidPrice").GetComponent<Text>();
        int price = System.Int32.Parse(text.text);
        if (price >= GlobalVariables.bandaidCost)
        {
            doctor.CmdSetBandaidPrice(price);
        }
    }

    public void SetStitchesPrice(Text text)
    {
        Doctor doctor = GameObject.Find("Local").GetComponent<Doctor>();
        //Text text = GameObject.Find("StitchesText").GetComponent<Text>();
        int price = Int32.Parse(text.text);
        if (price >= GlobalVariables.stitchesCost)
        {
            doctor.CmdSetStitchesPrice(price);
        }
    }

    public void NextPatient()
    {
        Doctor doctor = GameObject.Find("Local").GetComponent<Doctor>();
        Door door = FindObjectsOfType<Door>().First(x => x.doorID == doctor.doctorID);
        Patient patient = door.playerQueue.First();
        patient.CmdPopQueue(door.doorID);
    }

    public void ChangeRoom()
    {
        Doctor doctor = GameObject.Find("Local").GetComponent<Doctor>();

        doctor.SwitchRooms();
    }

}