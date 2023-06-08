using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMade : MonoBehaviour
{
    public PrankList list;
    public AudioSource source;
    public AudioSource swish;

    void Start(){
        source = GameObject.Find("swish").GetComponent<AudioSource>();
        swish = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Basketball")
        {
            // logic to check if it was made from half court or farther
            source.PlayOneShot(source.clip, 0.5f);
            Debug.Log("Hoop made");
            for (int i = 0;  i<list.PrankText.Length; i++)
            {
                if (list.PrankText[i].text == "Make a hoop in the gym!" && list.PrankText[i].color != Color.green)
                {
                    
                    list.PrankText[i].color = Color.green;
                    list.pranksdone++;
                }
            }
        }
    }
}
