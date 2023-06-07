using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballButton : MonoBehaviour
{
    public Animator mAnimator;
    public GameObject basketball;
    public GameObject kid;
    private int nPresses = 0;

    void Start()
    {
        
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Press()
    {
        mAnimator.SetTrigger("T1");
        if (nPresses < 20)
        {
            float roll = Random.value;
            if (roll <= .8f)
            {
                Instantiate(basketball, new Vector3(Random.Range(65f, 105f), 5f, Random.Range(70f,105f)), Quaternion.identity);
            }
            else
            {
                Instantiate(kid, new Vector3(Random.Range(65f, 105f), 5f, Random.Range(70f,105f)), Quaternion.identity);
            }
        }
        nPresses++;

    }
}
