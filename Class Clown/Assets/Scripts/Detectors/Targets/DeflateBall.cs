using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DeflateBall : MonoBehaviour
{
    public PrankList list;
    public Animator mAnimator;
    public AudioSource source;
    public AudioSource bounce;
    public Rigidbody rb;

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        source = GameObject.Find("pop").GetComponent<AudioSource>();
        bounce = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "spike")
        {
            mAnimator.SetTrigger("T1");
            source.PlayOneShot(source.clip, 2.0f);

            for (int i = 0; i < list.PrankText.Length; i++)
                {
                    if (list.PrankText[i].text == "Deflate a basketball" && list.PrankText[i].color != Color.green)
                    {
                        list.PrankText[i].color = Color.green;
                        list.pranksdone++;
                    }
                }
        }
        else
        {
            bounce.Play();
            rb.velocity *= .7f;
        }
    }
}
