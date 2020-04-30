using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    // Update is called once per frame
    void OnMouseDown()
    {
        Patient player = GameObject.FindObjectsOfType<Patient>().First(x => x.hasAuthority);
        Camera cam = player.GetComponentInChildren<Camera>();
        player.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        
    }
}
