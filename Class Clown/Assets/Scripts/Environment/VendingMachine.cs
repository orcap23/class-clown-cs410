using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public int numPlayerInteractions = 0;
    public Animator mAnimator;
    public PrankList list;
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
                numPlayerInteractions++;
            }
            else if (numPlayerInteractions == 4)
            {
                mAnimator.SetTrigger("T2");
                CheckOffPrank();
            }
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
        Destroy(this);
    }
}
