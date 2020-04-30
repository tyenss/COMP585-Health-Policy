using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
using Mirror;

[System.Serializable] 
public class WhiteboardText : NetworkBehaviour
{
    public int whiteboardID;
    public Text bandaid;
    public Text stitches;
    public Doctor doctor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    [Command]
    public void CmdChangeBandaidPrice()
    {
        Doctor doctor;

        if (whiteboardID > 6)
        {
            doctor = FindObjectsOfType<Doctor>().First(x => x.doctorID == whiteboardID - 6);
        }
        else
        {
            doctor = FindObjectsOfType<Doctor>().First(x => x.doctorID == whiteboardID);
        }
        bandaid.text = doctor.bandaidPrice.ToString();
        RpcChangeBandaidPrice(doctor.bandaidPrice);
    }

    [ClientRpc]
    public void RpcChangeBandaidPrice(int price)
    {
        bandaid.text = price.ToString();
    }

    
    public void ChangeStitchPrice() 
    { 
        Doctor doctor;

        if (whiteboardID > 6)
        {
            doctor = FindObjectsOfType<Doctor>().First(x => x.doctorID == whiteboardID - 6);
        }
        else
        {
            doctor = FindObjectsOfType<Doctor>().First(x => x.doctorID == whiteboardID);
        }
        stitches.text = doctor.stitchesPrice.ToString();
    }


}
