using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMade : MonoBehaviour
{
    public PrankList list;
    public AudioClip swish;
    AudioSource source; 
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Basketball")
        {
            // logic to check if it was made from half court or farther
            source = GetComponent<AudioSource>();
            Debug.Log("Hoop made");
            for (int i = 0;  i<list.PrankText.Length; i++)
            {
                if (list.PrankText[i].text == "Make a hoop in the gym!" && list.PrankText[i].color != Color.green)
                {
                    source.PlayOneShot(swish, 0.5f);
                    list.PrankText[i].color = Color.green;
                    list.pranksdone++;
                }
            }
        }
    }
}
