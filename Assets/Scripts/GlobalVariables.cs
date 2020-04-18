using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Unity.

public class GlobalVariables : MonoBehaviour
{
    public static int reinmbursment;
    public static int bandaidCost;
    public static int stitchesCost;
    public static int chanceOfOne;
    public static int maxDoctors;
    public static int patientMoney;
    public static int numberOfRounds;

    public static List<Patient> patientList;
    public static List<Doctor> doctorList;
    public static List<GameObject> buttons;

    /// <summary>
	/// Awake is used to instantiate variables before prefabs are instantiated
	/// </summary>
    public void Awake()
    {
        patientList = new List<Patient>();
        doctorList = new List<Doctor>();
        buttons = new List<GameObject>();
    }
}