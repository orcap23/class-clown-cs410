using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timerDuration = 3 * 60f;
    public float timerTime;
    public TMP_Text timer;
    public Color flashing;
    // Start is called before the first frame update
    void Start()
    {
        timerTime = timerDuration;
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        WaitForSeconds wait = new WaitForSeconds(.01f);
        while(timerTime > 0)
        {
            yield return wait;
            timerTime -= Time.deltaTime;
            UpdateTimer(timerTime);
        }
        yield return null;
    }

    private void UpdateTimer(float time)
    {
        int minute = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        if(time < (timerDuration / 2) && seconds % 2 == 0)
        {
            timer.color = flashing;
        }
        else
        {
            timer.color = Color.black;
        }
        timer.text = "Time: ";
        if(minute % 10 == minute)
        {
            timer.text += "0";
        }
        timer.text += minute + ":";
        if(seconds %10 == seconds)
        {
            timer.text += "0";
        }
        timer.text += seconds;
    }
}
