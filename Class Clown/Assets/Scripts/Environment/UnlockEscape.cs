using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UnlockEscape : MonoBehaviour
{
    // Start is called before the first frame update
    public PrankList list;
    public GameObject AlarmMessage;
    public bool pranksaredone = false;
    private static bool Escapable = false;
    public static bool alarmFlash = false;
    public static bool GetEscape
    {
        get { return Escapable;}
    }
    // Update is called once per frame
    private void Start()
    {
        AlarmMessage.TryGetComponent(out AlarmMessage msg);
        list.pranksdone = 0;
        alarmFlash = false;
        StartCoroutine(CheckifEscapeable());
    }
    private void Update()
    {
        if (pranksaredone)
        {
            pranksaredone = false;
            Escapable = true;
        }
        if (list.pranksdone == list.PrankText.Length && alarmFlash == false)
        {
            alarmFlash = true;
        }
    }
    private IEnumerator CheckifEscapeable()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
/*            Debug.Log("pranks done: " + list.pranksdone);
            Debug.Log("Prank length: " + list.PrankText.Length/2);*/
            if (list.pranksdone >= (list.PrankText.Length / 2))
            {
                pranksaredone = true;
                break;
            }
        }
        yield return null;
    }
    
}
