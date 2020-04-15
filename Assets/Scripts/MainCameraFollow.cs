using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollow : MonoBehaviour
{
    public Transform PlayerTransform;

 
    // Start is called before the first frame update
    void Start()
    {
        //PlayerTransform = GameObject.Find("Local").transform;
        
    }

    // Update is called once per frame
    
    void Update()
    {

        PlayerTransform = GameObject.Find("Local").transform;
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, PlayerTransform.position.z-400);

    }
    
}
