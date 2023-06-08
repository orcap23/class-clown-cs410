using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public int numPlayerInteractions = 0;
    public Animator mAnimator;
    public PrankList list;
    public AudioSource [] sources;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (mAnimator != null)
        {
            if (numPlayerInteractions < 4)
            {
                mAnimator.SetTrigger("T1");
                sources[0].Play();
            }
            else if (numPlayerInteractions == 4)
            {
                mAnimator.SetTrigger("T2");
                sources[0].Play();
                sources[0].Play();
                sources[1].Play();
                CheckOffPrank();
            }
            numPlayerInteractions++;
        }
        else{
            Debug.Log("mAnimator is null");
        }


    }
    public void CheckOffPrank()
    {
        for (int i = 0;  i<list.PrankText.Length; i++)
        {
            if (list.PrankText[i].text == "Knock over the cafeteria vending machine >:)" && list.PrankText[i].color != Color.green)
            {
                list.PrankText[i].color = Color.green;
                list.pranksdone++;
            }
        }
        gameObject.tag = "Untagged";
    }
}
