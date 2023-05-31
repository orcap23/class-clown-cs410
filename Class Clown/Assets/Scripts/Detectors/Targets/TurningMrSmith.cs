using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningMrSmith : MonoBehaviour
{
    // Start is called before the first frame update
    public Turn spinningSmith;
    public PrankList list;
    // Update is called once per frame
    void Update()
    {
        if (spinningSmith.fallen)
        {
            for (int i = 0; i < list.PrankText.Length; i++)
            {
                if (list.PrankText[i].text == "Knock over Mr.Smith" && list.PrankText[i].color != Color.green)
                {
                    list.PrankText[i].color = Color.green;
                    list.pranksdone++;
                }
            }
        }
    }
}
