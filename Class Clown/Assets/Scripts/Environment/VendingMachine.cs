using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public int numPlayerInteractions = 0;
    public Animator mAnimator;

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
            }
            else if (numPlayerInteractions == 4)
            {
                mAnimator.SetTrigger("T2");
            }
            numPlayerInteractions++;
        }
        else{
            Debug.Log("mAnimator is null");
        }
        
    }
}
