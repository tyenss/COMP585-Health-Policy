using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminScreen : MonoBehaviour
{
    public InputField bandaid;
    public InputField stitches;
    public InputField doctors;
    public InputField defaultPatientMoney;
    public InputField numberOfRounds;
    public InputField reinbursment;
    public InputField chanceOfOne;

    public void SetVariables()
    {
        GlobalVariables.bandaidCost = Int32.Parse(bandaid.text);
        GlobalVariables.stitchesCost = Int32.Parse(stitches.text);
        GlobalVariables.reinmbursment = Int32.Parse(reinbursment.text);
        GlobalVariables.patientMoney = Int32.Parse(defaultPatientMoney.text);
        GlobalVariables.numberOfRounds = Int32.Parse(numberOfRounds.text);
        GlobalVariables.maxDoctors = Int32.Parse(doctors.text);
        GlobalVariables.chanceOfOne = Int32.Parse(chanceOfOne.text);
    }
}
