using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
    public AudioSource [] src;
    private bool pied;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Teacher Smith" && !pied)
        {
            src[0].Play();
            pied = true;
        }
        else
        {
            src[1].Play();
        }
    }
}
