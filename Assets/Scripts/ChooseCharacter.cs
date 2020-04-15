using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour
{
    public GameObject patient;
    public GameObject doctor;

    int currentCharacter = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(doctor);
        
        
    }

    public void SwitchAvatar()
    {
        switch (currentCharacter)
        {
            case 1:
                
                currentCharacter = 2;
                patient.gameObject.SetActive(false);
                doctor.gameObject.SetActive(true);
                break;

            case 2:
                //GameObject patient1= GameObject.Instantiate(patient);
                //patient1.GetComponent<Camera>().enable = true;
                currentCharacter = 1;
                patient.gameObject.SetActive(true);
                doctor.gameObject.SetActive(false);
                break;
        }
    }

    
}
