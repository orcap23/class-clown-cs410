using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRoom : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(267,1.3f,82);
            //camera.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
    }
}
