using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.

public class GlobalVariables : MonoBehaviour
{
    public static decimal reinmbursment;
    public static decimal bandaidCost;
    public static decimal stitchesCost;

    public static List<Patient> patientList;
    public static List<Doctor> doctorList;

    public void Awake()
    {
        patientList = new List<Patient>();
        doctorList = new List<Doctor>();
    }
}