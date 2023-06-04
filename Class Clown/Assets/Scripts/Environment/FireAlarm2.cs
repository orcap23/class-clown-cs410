using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarm2 : MonoBehaviour
{
    public GameObject EndDoor;
    private bool isOpen;
    public void FinalExit()
    {
        GameObject manager = GameObject.Find("Managers");
        manager.TryGetComponent(out UnlockEscape unlockescape);
        
        //Debug.Log("Here");
        if (UnlockEscape.GetEscape && !isOpen)
        {   
            //Debug.Log("Pranks Done!");
            if (EndDoor.TryGetComponent(out Animator doorL))
            {
                doorL.SetTrigger("T1");
                isOpen = true;
                //Debug.Log("Set Trigger");
            }
            else
            {
                Debug.Log("FireAlarm2: Can't find animator");
            }
        }
    }
}
