using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamster : MonoBehaviour
{
    // Start is called before the first frame update
    public PrankList list;
    public Interact player;
    private bool heldhamster = false;
    // Update is called once per frame
    void Update()
    {
        if (player.GetHeld != null && !heldhamster)
        {
            if (player.GetHeld.name == transform.name)
            {
                for (int i = 0; i < list.PrankText.Length; i++)
                {
                    if (list.PrankText[i].text == "Chuck the Hamster" && list.PrankText[i].color != Color.green)
                    {
                        list.PrankText[i].color = Color.green;
                        list.pranksdone++;
                        heldhamster = true;
                    }
                }
            }
        }
    }
}
