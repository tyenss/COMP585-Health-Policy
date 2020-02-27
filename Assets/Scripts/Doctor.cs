using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    protected decimal moneyMade;
    private decimal bandaidPrice;
    private decimal stitchesPrice;
    protected int doctorID;
    private int bandaidsSold;
    private int stitchesSold;

    // Start is called before the first frame update
    void Start()
    {
        moneyMade = 0;
        bandaidsSold = 0;
        stitchesSold = 0;
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

    public bool SetBandaidPrice(decimal price)
    {
        if (price <= GlobalVariables.bandaidCost)
        {
            return false;
        }
        bandaidPrice = price;
        return true;
    }

    public bool SetStitchesPrice(decimal price)
    {
        if (price <= GlobalVariables.stitchesCost)
        {
            return false;
        }
        stitchesPrice = price;
        return true;
    }
}
