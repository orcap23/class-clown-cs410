using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Basketball")
        {
            // logic to check if it was made from half court or farther
            Debug.Log("Hoop made");
        }
    }
}
