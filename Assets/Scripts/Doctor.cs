using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    public GameObject PlayerCamera;
    public int bandaidPrice;
    public int stitchesPrice;
    public bool inOffice; //if 0, in lobby; else, in office
	//public bool hasClient;

    protected decimal moneyMade;
    public int doctorID;
    private int bandaidsSold;
    private int stitchesSold;

    // Start is called before the first frame update
    void Start()
    {
        //if (isLocalPlayer)
        //{
        //    PlayerCamera.SetActive(true);
        //}
        //else
        //{
        //    PlayerCamera.SetActive(false);
        //}
        moneyMade = 0;
        bandaidsSold = 0;
        stitchesSold = 0;
        inOffice = true;
        GlobalVariables.doctorList.Add(this);
        doctorID = GlobalVariables.doctorList.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BandaidSold()
    {
        bandaidsSold++;
        moneyMade += bandaidPrice + GlobalVariables.reinmbursment - GlobalVariables.bandaidCost;
    }

    public int getBandaidsSold()
    {
        return bandaidsSold;
    }

    public void StitchesSold()
    {
        stitchesSold++;
        moneyMade += stitchesPrice + GlobalVariables.reinmbursment - GlobalVariables.stitchesCost;
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
            
		}
		else if (!inOffice)
		{

		}

		inOffice = !inOffice;
	}
}
