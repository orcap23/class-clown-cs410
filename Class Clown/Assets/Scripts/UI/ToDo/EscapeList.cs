using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EscapeList : MonoBehaviour
{
    public TMP_Text [] alarmState;
    private bool toggle;
    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < alarmState.Length; i++)
        {
            alarmState[i].GetComponent<TMP_Text>();
            alarmState[i].enabled = false;
        }
    }

    void Update()
    {
        if (UnlockEscape.alarmFlash && !toggle)
        {
            alarmState[0].enabled = true;
            toggle = true;
        }
    }
}
