using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSound : MonoBehaviour
{
    public AudioSource src;

    void Start()
    {
        src = GetComponent<AudioSource>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        src.Play();
    }
}
