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

    /// <summary>
	/// Awake is used to instantiate variables before prefabs are instantiated
	/// </summary>
    public void Awake()
    {
        patientList = new List<Patient>();
        doctorList = new List<Doctor>();
    }
}