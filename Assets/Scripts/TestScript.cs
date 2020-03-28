using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    /// database access for queue
    public void QueueDB()
    {
        //StartCoroutine(addPatient());
    }

    IEnumerator AddPatient()
    {
        WWWForm form = new WWWForm();
        ///form.AddField("name", player.name);
        WWW www = new WWW("http://localhost/sqlconnect/connection.php");
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Patient added successfully");
        }
        else
        {
            Debug.Log("error");
        }
    }
}
