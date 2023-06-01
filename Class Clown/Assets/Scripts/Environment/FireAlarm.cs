using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireAlarm : MonoBehaviour
{
    public Openable lockeddoor;
    public void Escape()
    {
        Debug.Log(UnlockEscape.GetEscape);
        if (UnlockEscape.GetEscape)
        {
            lockeddoor.locked = false;
            Debug.Log("Escape");
        }
    }
}
