using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    [SerializeField] private bool isopen = false;
    public void open()
    {
        if (!isopen)
        {

            transform.RotateAround(new Vector3(transform.position.x, transform.position.y, transform.position.z - .75f), transform.up, 90f);
            isopen = true;
        }
        else
        {
            transform.RotateAround(new Vector3(transform.position.x - .75f, transform.position.y, transform.position.z), transform.up, -90f);
            isopen = false;
        }
    }

}
