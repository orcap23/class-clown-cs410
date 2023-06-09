using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassToHallway : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.transform.position = new Vector3(0,1.3f,0);
            other.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
    }
}
