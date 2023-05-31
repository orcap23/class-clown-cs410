using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireAlarm : MonoBehaviour
{
    public void Escape()
    {
        Debug.Log(UnlockEscape.GetEscape);
        if (UnlockEscape.GetEscape)
            Debug.Log("Escape");
    }
}
