using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceChanges : MonoBehaviour
{
    public Text changingPrice;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changePrice() {
        changingPrice.text = ""
    }
}
