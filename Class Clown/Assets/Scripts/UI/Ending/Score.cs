using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public static int num_detected;
    public PrankList pranks;
    public GameObject[] stars = new GameObject[5];
    private float score = 0;

    public void updateScore(TMP_Text scoretext,TMP_Text speed, TMP_Text pranknum, TMP_Text timesdetected)
    {
        if(Timer.timerTime == 0)
        {
            score = 0;
        }
        else
        {
            score = num_detected < 5 ? 
                (1000 * pranks.pranksdone) + (Timer.timerTime * (10 - num_detected)) :
                (100 * pranks.pranksdone) + (Timer.timerTime * (10 - num_detected));
        }
        scoretext.text = "Score: " + score;
        speed.text = "Speed :" + Timer.timerTime * 10;
        pranknum.text = "Pranks Accomplished: " + pranks.pranksdone;
        timesdetected.text = "Times detected: " + num_detected;
        if(score > 1000)
        {
            stars[0].SetActive(true);
        }
        if (score > 2000)
        {
            stars[1].SetActive(true);
        }
        if (score > 3000)
        {
            stars[2].SetActive(true);
        }
        if (score > 4000)
        {
            stars[3].SetActive(true);
        }
        if (score > 5000)
        {
            stars[4].SetActive(true);
        }
    }
}