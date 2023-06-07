using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongBall : MonoBehaviour
{
    // Start is called before the first frame update
    public PrankList list;
    public Interact player;
    // Update is called once per frame
    void Update()
    {
        if (player.GetHeld != null)
        {
            if (player.GetHeld.name == transform.name)
            {
                for (int i = 0; i < list.PrankText.Length; i++)
                {
                    if (list.PrankText[i].text == "Steal the ping pong ball" && list.PrankText[i].color != Color.green)
                    {
                        list.PrankText[i].color = Color.green;
                        list.pranksdone++;
                    }
                }
            }
        }
    }
}
