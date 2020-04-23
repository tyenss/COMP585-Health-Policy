using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class Doctor : NetworkBehaviour
{
    public GameObject PlayerCamera;
    public GameObject canvas;
    public int bandaidPrice;
    public int stitchesPrice;
    public bool inOffice; //if 0, in lobby; else, in office
    public Vector3 officeCoord;
	//public bool hasClient;

    public int money;
    public int doctorID;
    private int bandaidsSold;
    private int stitchesSold;
    
    // Start is called before the first frame update
    void Start()
    {
        if (base.hasAuthority)
        {
            PlayerCamera.SetActive(true);
            canvas.SetActive(true);

        }
        else
        {
            PlayerCamera.SetActive(false);
            canvas.SetActive(false);
        }
        gameObject.name = "Local";
        bandaidPrice = GlobalVariables.bandaidCost;
        stitchesPrice = GlobalVariables.stitchesCost;

        money = 0;
        bandaidsSold = 0;
        stitchesSold = 0;
        inOffice = true;
        GlobalVariables.doctorList.Add(this);
        doctorID = GlobalVariables.doctorList.Count;
        officeCoord = transform.position; 
    }
    /*
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.name = "Local";
    }
    */
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        // gameObject.name = "Local";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BandaidSold()
    {
        bandaidsSold++;
        money += bandaidPrice + GlobalVariables.reinmbursment - GlobalVariables.bandaidCost;
    }

    public int GetBandaidsSold()
    {
        return bandaidsSold;
    }

    public void StitchesSold()
    {
        stitchesSold++;
        money += stitchesPrice + GlobalVariables.reinmbursment - GlobalVariables.stitchesCost;
    }

    public int GetStitchesSold()
    {
        return stitchesSold;
    }

    public bool SetBandaidPrice(int price)
    {
        if (price <= GlobalVariables.bandaidCost)
        {
            return false;
        }
        bandaidPrice = price;
        return true;
    }

    public bool SetStitchesPrice(int price)
    {
        if (price <= GlobalVariables.stitchesCost)
        {
            return false;
        }
        stitchesPrice = price;
        return true;
    }

    /// <summary>
	/// Switch rooms between lobby and office
	/// </summary>
	public void SwitchRooms()
	{
		if (inOffice)
		{
            transform.position = new Vector3(0f, 0f, 0f);
            inOffice = false;
		}
		else if (!inOffice)
		{
            transform.position = officeCoord;
            inOffice = true;
        }

		//inOffice = !inOffice;
	}
}
