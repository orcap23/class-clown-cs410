using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeflateBall : MonoBehaviour
{
    public PrankList list;
    public Animator mAnimator;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "spike")
        {
            mAnimator.SetTrigger("T1");

            for (int i = 0; i < list.PrankText.Length; i++)
                {
                    if (list.PrankText[i].text == "Deflate a basketball" && list.PrankText[i].color != Color.green)
                    {
                        list.PrankText[i].color = Color.green;
                        list.pranksdone++;
                    }
                }
        }
    }
}
