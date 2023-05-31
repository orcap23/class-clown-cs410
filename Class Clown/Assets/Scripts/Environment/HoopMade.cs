using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMade : MonoBehaviour
{
    public PrankList list;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Basketball")
        {
            // logic to check if it was made from half court or farther
            Debug.Log("Hoop made");
            for (int i = 0;  i<list.PrankText.Length; i++)
            {
                if (list.PrankText[i].text == "Make a half court shot" && list.PrankText[i].color != Color.green)
                {
                    list.PrankText[i].color = Color.green;
                    list.pranksdone++;
                }
                if (list.PrankText[i].text == "Make a hoop" && list.PrankText[i].color != Color.green)
                {
                    list.PrankText[i].color = Color.green;
                    list.pranksdone++;
                }
            }
        }
    }
}
