using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedSmith : MonoBehaviour
{
    public PrankList list;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "pie")
        {
            for (int i = 0; i < list.PrankText.Length; i++)
                {
                    if (list.PrankText[i].text == "Pie a teacher" && list.PrankText[i].color != Color.green)
                    {
                        list.PrankText[i].color = Color.green;
                        list.pranksdone++;
                    }
                }
        }
    }
}
