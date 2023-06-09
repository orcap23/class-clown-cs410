using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireAlarm : MonoBehaviour
{
    public Openable lockeddoor;
    public EscapeList list;
    public AlarmMessage alarmMsg;
    public void Escape()
    {
        Debug.Log(UnlockEscape.GetEscape);
        if (UnlockEscape.GetEscape)
        {
            list.alarmState[0].enabled = false;
            list.alarmState[1].enabled = true;
            lockeddoor.locked = false;
            //Debug.Log("Escape");
        }
    }
}
