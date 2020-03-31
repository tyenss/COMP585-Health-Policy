using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ButtonHandler : MonoBehaviour
{
    public void BuyStitches()
    {
        Patient patient = GameObject.Find("Local").GetComponent<Patient>();
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
            patient.cured.text = "Cured: Yes";
            EnableDisableButtons(false);
        }
    }

    public void BuyBandaid()
    {
        Patient patient = GameObject.Find("Local").GetComponent<Patient>();
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
            patient.cured.text = "Cured: Yes";
            EnableDisableButtons(false);
        }
    }

    public void EnterRoom()
    {
        Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        if (patient.GetDoor() != null)
        {
            patient.roomID = patient.GetDoor().doorID;
            //this.transform.position = this.GetDoor().officeCoords;
            patient.GetDoor().PopQueue();
            //this.door = null;
        }
    }

    public void LeaveRoom()
    {
        Patient patient = GameObject.Find("Local").GetComponent<Patient>();
        patient.roomID = 0;
        patient.transform.position = new Vector3(0f, 0f, 0f);
    }

    /// <summary>
    /// Makes patient buttons active or inactive
    /// </summary>
    /// <param name="b">true: active, false: inactive</param>
    public static void EnableDisableButtons(bool b)
    {
        if (GlobalVariables.buttons.Count == 0)
        {
            GlobalVariables.buttons.AddRange(GameObject.FindGameObjectsWithTag("PatientButton"));
        }
        foreach (GameObject button in GlobalVariables.buttons)
        {
            button.SetActive(b);
        }
    }

    public void SetBandaidPrice()
    {
        Doctor doctor = GameObject.Find("Local").GetComponent<Doctor>();
        int price = 0;
        if (price <= GlobalVariables.bandaidCost)
        {
            
        }
    }

    public void SetStitchesPrice()
    {
        Doctor doctor = GameObject.Find("Local").GetComponent<Doctor>();
        int price = 0;
        if (price <= GlobalVariables.stitchesCost)
        {

        }
    }

    public void NextPatient()
    {
        Doctor doctor = GameObject.Find("Local").GetComponent<Doctor>();
        Door door = FindObjectsOfType<Door>().First(x => x.doorID == doctor.doctorID);
        door.PopQueue();
    }
}
